//
//  PlayInstallReferrerDetails.cs
//  PlayInstallReferrer
//
//  Created by Uglješa Erceg (@uerceg) on 12th April 2020.
//  Copyright © 2020 Uglješa Erceg. All rights reserved.
//

using System;
using System.Collections.Generic;

namespace BlackBox.PlayInstallReferrerPlugin
{
    public class PlayInstallReferrerDetails
    {
        public string InstallReferrer { get; }
        public long? ReferrerClickTimestampSeconds { get; }
        public long? InstallBeginTimestampSeconds { get; }
        public bool? GooglePlayInstant { get; }
        public PlayInstallReferrerError Error { get; }

        internal PlayInstallReferrerDetails(
            string installReferrer,
            long referrerClickTimestampSeconds,
            long installBeginTimestampSeconds,
            bool googlePlayInstant)
        {
            InstallReferrer = installReferrer;
            ReferrerClickTimestampSeconds = referrerClickTimestampSeconds;
            InstallBeginTimestampSeconds = installBeginTimestampSeconds;
            GooglePlayInstant = googlePlayInstant;
        }

        internal PlayInstallReferrerDetails(PlayInstallReferrerError error)
        {
            Error = error;
        }
    }
}
