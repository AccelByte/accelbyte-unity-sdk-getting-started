﻿// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class PublicUserProfile
    {
        [DataMember] public string userId { get; set; }
        [DataMember] public string @namespace { get; set; }
        [DataMember] public string timeZone { get; set; }
        [DataMember] public string avatarSmallUrl { get; set; }
        [DataMember] public string avatarUrl { get; set; }
        [DataMember] public string avatarLargeUrl { get; set; }
    }
}