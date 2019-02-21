// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class PagedWalletTransactions
    {
        [DataMember] public WalletTransaction[] data { get; set; }
        [DataMember] public Paging paging { get; set; }
    }

    [DataContract]
    public class WalletTransaction
    {
        [DataMember] public string walletId { get; set; }
        [DataMember] public int amount { get; set; }
        [DataMember] public string reason { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public string @operator { get; set; }
        [DataMember] public string walletAction { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string balanceSource { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
    }
}