// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using UnityEngine;

namespace AccelByte.Core
{
    public enum LogType
    {
        Debug,
        Info,
        Warning,
        Error,
        All
    }

    public class Logger
    {
        public static bool Enable = true;

        public static void Print(LogType logtype, string message)
        {
            if (!Enable)
            {
                return;
            }

            string formattedMessage = "[" + logtype.ToString() + "] " + message;
            Debug.Log(formattedMessage);
        }
    }
}