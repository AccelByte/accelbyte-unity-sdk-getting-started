// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class PlatformLink
    {
        [DataMember] public string PlatformId { get; set; }
        [DataMember] public string PlatformUserId { get; set; }
        [DataMember] public string Namespace { get; set; }
        [DataMember] public string UserId { get; set; }
    }
}