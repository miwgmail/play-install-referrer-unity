﻿using System;
using System.Collections.Generic;

namespace BlackBox.PlayInstallReferrerPlugin
{
    public class PlayInstallReferrerDetails
    {
        public string InstallReferrer { get; }
        public long? ReferrerClickTimestampSeconds { get; }
        public long? InstallBeginTimestampSeconds { get; }
        public bool? GooglePlayInstant { get; }

        internal PlayInstallReferrerDetails(
            string installReferrer,
            long referrerClickTimestampSeconds,
            long installBeginTimestampSeconds,
            bool googlePlayInstant)
        {
            this.InstallReferrer = installReferrer;
            this.ReferrerClickTimestampSeconds = referrerClickTimestampSeconds;
            this.InstallBeginTimestampSeconds = installBeginTimestampSeconds;
            this.GooglePlayInstant = googlePlayInstant;
        }
    }
}
