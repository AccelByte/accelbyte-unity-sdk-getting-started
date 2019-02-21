// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class RegionData
    {
        [DataMember] public int price { get; set; }
        [DataMember] public int discountPercentage { get; set; }
        [DataMember] public int discountAmount { get; set; }
        [DataMember] public int discountedPrice { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string currencyType { get; set; }
        [DataMember] public string currencyNamespace { get; set; }
        [DataMember] public DateTime purchaseAt { get; set; }
        [DataMember] public DateTime expireAt { get; set; }
        [DataMember] public int totalNum { get; set; }
        [DataMember] public int totalNumPerAccount { get; set; }
        [DataMember] public DateTime discountPurchaseAt { get; set; }
        [DataMember] public DateTime discountExpireAt { get; set; }
        [DataMember] public int discountTotalNum { get; set; }
        [DataMember] public int discountTotalNumPerAccount { get; set; }
    }
}
