using System;
using UnityEngine;

namespace UE.InstallReferrerApi
{
    public class InstallReferrer : MonoBehaviour
    {
        private const string errorMsgEditor = "[InstallReferrer]: InstallReferrer plugin can not be used in Editor.";
        private const string errorMsgPlatform = "[InstallReferrer]: InstallReferrer plugin can only be used in Android apps.";

        void Awake()
        {
            if (IsEditor())
            {
                return;
            }

            DontDestroyOnLoad(transform.gameObject);
        }

        // Public API
        public static void GetInstallReferrerInfo(Action<InstallReferrerDetails> callback)
        {
            if (IsEditor())
            {
                return;
            }

#if UNITY_ANDROID
            InstallReferrerAndroid.GetInstallReferrerInfo(callback);
#endif
        }

        // Private API
        private static bool IsEditor()
        {
#if UNITY_EDITOR
            Debug.Log(errorMsgEditor);
            return true;
#else
            return false;
#endif
        }
    }
}
