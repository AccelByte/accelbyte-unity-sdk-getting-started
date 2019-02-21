// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class OrderHistoryInfo
    {
        [DataMember] public string orderNo { get; set; }
        [DataMember] public string @operator { get; set; }
        [DataMember] public string action { get; set; }
        [DataMember] public string reason { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
    }
}