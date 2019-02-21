// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class WalletInfo
    {
        [DataMember] public string id { get; set; }
        [DataMember] public string @namespace { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string currencySymbol { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
        [DataMember] public double balance { get; set; }
        [DataMember] public string status { get; set; }
    }
}