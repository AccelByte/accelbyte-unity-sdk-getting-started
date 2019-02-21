// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class BalanceInfo
    {
        [DataMember] public string id { get; set; }
        [DataMember] public string walletId { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public int balance { get; set; }
        [DataMember] public string balanceSource { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
        [DataMember] public string status { get; set; }
    }
}
