//
//  PlayInstallReferrerError.cs
//  PlayInstallReferrer
//
//  Created by Uglješa Erceg (@uerceg) on 12th April 2020.
//  Copyright © 2020 Uglješa Erceg. All rights reserved.
//

using System;

namespace BlackBox.PlayInstallReferrerPlugin
{
    public class PlayInstallReferrerError
    {
        public int ResponseCode { get; }
        public Exception Exception { get; }

        internal PlayInstallReferrerError(int responseCode, Exception exception)
        {
            ResponseCode = responseCode;
            Exception = exception;
        }
    }
}
