// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class UpdateUserRequest
    {
        [DataMember] public string Country { get; set; }
        [DataMember] public string DisplayName { get; set; }
        [DataMember] public string EmailAddress { get; set; }
        [DataMember] public string LanguageTag { get; set; }
    }
}