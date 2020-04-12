using System;
using UnityEngine;

namespace BlackBox.PlayInstallReferrerPlugin
{
    public class PlayInstallReferrer : MonoBehaviour
    {
        public static void GetInstallReferrerInfo(Action<PlayInstallReferrerDetails> callback)
        {
#if UNITY_ANDROID
            PlayInstallReferrerAndroid.GetInstallReferrerInfo(callback);
#elif UNITY_EDITOR
            Debug.Error("play-install-referrer plugin can not be used in Editor.");
            return;
#else
            Debug.Error("play-install-referrer plugin can only be used in Android apps.");
#endif
        }
    }
}
