using System;
using System.Collections.Generic;

namespace UE.InstallReferrerApi
{
    public class InstallReferrerDetails
    {
        public string InstallReferrer { get; }
        public bool? GooglePlayInstantParam { get; }
        public long? InstallBeginTimestampSeconds { get; }
        public long? ReferrerClickTimestampSeconds { get; }

        public InstallReferrerDetails(
            string installReferrer,
            bool googlePlayInstantParam,
            long installBeginTimestampSeconds,
            long referrerClickTimestampSeconds)
        {
            this.InstallReferrer = installReferrer;
            this.GooglePlayInstantParam = googlePlayInstantParam;
            this.InstallBeginTimestampSeconds = installBeginTimestampSeconds;
            this.ReferrerClickTimestampSeconds = referrerClickTimestampSeconds;
        }
    }
}
