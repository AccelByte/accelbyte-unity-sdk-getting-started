// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;
using AccelByte.Api;

namespace AccelByte.Models
{
    [DataContract]
    public class UserInfo
    {
        [DataMember] public AuthenticationType AuthType { get; set; }
        [DataMember] public string DisplayName { get; set; }
        [DataMember(Name = "LoginId")] public string UserName { get; set; }
        [DataMember] public string Password { get; set; }
    }
}