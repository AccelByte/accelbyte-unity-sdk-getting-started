// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class OrderRequest
    {
        [DataMember] public string itemId { get; set; }
        [DataMember] public int quantity { get; set; }
        [DataMember] public int price { get; set; }
        [DataMember] public int discountedPrice { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string returnUrl { get; set; }
        [DataMember] public string region { get; set; }
    }
}