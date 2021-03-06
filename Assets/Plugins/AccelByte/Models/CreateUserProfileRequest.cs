﻿// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class CreateUserProfileRequest
    {
        [DataMember] public string firstName { get; set; }
        [DataMember] public string lastName { get; set; }
        [DataMember] public string language { get; set; }
        [DataMember] public string avatarSmallUrl { get; set; }
        [DataMember] public string avatarUrl { get; set; }
        [DataMember] public string avatarLargeUrl { get; set; }
        [DataMember] public string timeZone { get; set; }
        [DataMember] public string dateOfBirth { get; set; }
    }
}