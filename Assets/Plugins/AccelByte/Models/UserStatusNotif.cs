// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Api
{
    [DataContract]
    public class UserStatusNotif
    {
        [DataMember] public string userID;
        [DataMember] public string availability;
        [DataMember] public string activity;
        [DataMember] public DateTime lastSeenAt;
    }
}