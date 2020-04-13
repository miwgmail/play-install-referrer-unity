using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UE.InstallReferrerApi
{
#if UNITY_ANDROID
    public class InstallReferrerAndroid
    {
        private static InstallReferrerStateListener installReferrerStateProxy;
        private static AndroidJavaObject ajoInstallReferrerClient;
        private static Dictionary<int, string> installReferrerResponseCodes;

        // Public API
        public static void GetInstallReferrerInfo(Action<InstallReferrerDetails> callback)
        {
            ajoInstallReferrerClient = GetInstallReferrerClient();
            if (ajoInstallReferrerClient == null)
            {
                Debug.LogError("Unable to obtain InstallReferrerClient instance");
                return;
            }

            installReferrerStateProxy = new InstallReferrerStateListener(callback);
            ajoInstallReferrerClient.Call("startConnection", installReferrerStateProxy);
        }

        // Private API
        private static AndroidJavaObject GetInstallReferrerClient()
        {
            if (ajoInstallReferrerClient == null)
            {
                AndroidJavaObject ajoCurrentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaClass ajcInstallReferrerClient = new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient");
                ajoInstallReferrerClient = ajcInstallReferrerClient.CallStatic<AndroidJavaObject>("newBuilder", ajoCurrentActivity).Call<AndroidJavaObject>("build");
            }
            if (installReferrerResponseCodes == null)
            {
                installReferrerResponseCodes = new Dictionary<int, string>();
                installReferrerResponseCodes.Add(new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient$InstallReferrerResponse").GetStatic<int>("OK"), "OK");
                installReferrerResponseCodes.Add(new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient$InstallReferrerResponse").GetStatic<int>("FEATURE_NOT_SUPPORTED"), "FEATURE_NOT_SUPPORTED");
                installReferrerResponseCodes.Add(new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient$InstallReferrerResponse").GetStatic<int>("SERVICE_UNAVAILABLE"), "SERVICE_UNAVAILABLE");
                installReferrerResponseCodes.Add(new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient$InstallReferrerResponse").GetStatic<int>("DEVELOPER_ERROR"), "DEVELOPER_ERROR");
                installReferrerResponseCodes.Add(new AndroidJavaClass("com.android.installreferrer.api.InstallReferrerClient$InstallReferrerResponse").GetStatic<int>("SERVICE_DISCONNECTED"), "SERVICE_DISCONNECTED");
            }

            return ajoInstallReferrerClient;
        }

        private class InstallReferrerStateListener : AndroidJavaProxy
        {
            private Action<InstallReferrerDetails> callback;

            public InstallReferrerStateListener(Action<InstallReferrerDetails> pCallback) : base("com.android.installreferrer.api.InstallReferrerStateListener")
            {
                this.callback = pCallback;
            }

            public void onInstallReferrerSetupFinished(int responseCode)
            {
                try
                {
                    if (responseCode == installReferrerResponseCodes.FirstOrDefault(x => x.Value == "OK").Key)
                    {
                        Debug.Log("InstallReferrerResponse.OK status code received");
                        AndroidJavaObject ajoReferrerDetails = ajoInstallReferrerClient.Call<AndroidJavaObject>("getInstallReferrer");
                        if (ajoReferrerDetails == null)
                        {
                            Debug.LogError("getInstallReferrer returned null AndroidJavaObject!");
                            return;
                        }

                        String installReferrer = ajoReferrerDetails.Call<string>("getInstallReferrer");
                        long referrerClickTimestampSeconds = ajoReferrerDetails.Call<long>("getReferrerClickTimestampSeconds");
                        long installBeginTimestampSeconds = ajoReferrerDetails.Call<long>("getInstallBeginTimestampSeconds");
                        bool googlePlayInstantParam = ajoReferrerDetails.Call<bool>("getGooglePlayInstantParam");

                        InstallReferrerDetails installReferrerDetails = new InstallReferrerDetails(
                            installReferrer,
                            googlePlayInstantParam,
                            installBeginTimestampSeconds,
                            referrerClickTimestampSeconds);
                        this.callback(installReferrerDetails);
                    }
                    else if (responseCode == installReferrerResponseCodes.FirstOrDefault(x => x.Value == "FEATURE_NOT_SUPPORTED").Key)
                    {
                        Debug.LogError("InstallReferrerResponse.FEATURE_NOT_SUPPORTED status code received");
                    }
                    else if (responseCode == installReferrerResponseCodes.FirstOrDefault(x => x.Value == "SERVICE_UNAVAILABLE").Key)
                    {
                        Debug.LogError("InstallReferrerResponse.SERVICE_UNAVAILABLE status code received");
                    }
                    else if (responseCode == installReferrerResponseCodes.FirstOrDefault(x => x.Value == "DEVELOPER_ERROR").Key)
                    {
                        Debug.LogError("InstallReferrerResponse.DEVELOPER_ERROR status code received");
                    }
                    else if (responseCode == installReferrerResponseCodes.FirstOrDefault(x => x.Value == "SERVICE_DISCONNECTED").Key)
                    {
                        Debug.LogError("InstallReferrerResponse.SERVICE_DISCONNECTED status code received");
                    }
                    else
                    {
                        Debug.LogError("Unexpected response code arrived!");
                        Debug.LogError("Response: " + responseCode);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Exception: " + e);
                }
            }

            public void onInstallReferrerServiceDisconnected()
            {
                Debug.Log("onInstallReferrerServiceDisconnected invoked");
            }
        }
    }
#endif
}
