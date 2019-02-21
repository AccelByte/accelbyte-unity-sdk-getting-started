// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class FriendsStatus
    {
        [DataMember] public string[] friendsId;
        [DataMember] public string[] availability;
        [DataMember] public string[] activity;
        [DataMember] public DateTime[] lastSeenAt;
    }
}