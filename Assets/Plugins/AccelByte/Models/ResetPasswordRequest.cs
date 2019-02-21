// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class ResetPasswordRequest
    {
        [DataMember] public string Code { get; set; }
        [DataMember] public string LoginID { get; set; }
        [DataMember] public string NewPassword { get; set; }
    }
}