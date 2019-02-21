// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;
using AccelByte.Api;

namespace AccelByte.Models
{
    [DataContract]
    public class UserData
    {
        [DataMember] public string Namespace { get; set; }
        [DataMember] public string UserId { get; set; }
        [DataMember] public string DisplayName { get; set; }
        [DataMember] public string AuthType { get; set; }
        [DataMember] public string LoginId { get; set; }
        [DataMember] public string EmailAddress { get; set; }
        [DataMember] public string OldEmailAddress { get; set; }
//        [DataMember] public DateTime CreatedAt { get; set; }
        [DataMember] public bool PhoneVerified { get; set; }
        [DataMember] public bool EmailVerified { get; set; }
        [DataMember] public bool Enabled { get; set; }
//        [DataMember] public DateTime LastEnabledChangedTime { get; set; }
        [DataMember] public string Country { get; set; }
    }
}