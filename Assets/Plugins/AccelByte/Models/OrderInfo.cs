// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class OrderInfo
    {
        [DataMember] public string orderNo { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public string itemId { get; set; }
        [DataMember] public bool sandbox { get; set; }
        [DataMember] public int quantity { get; set; }
        [DataMember] public int price { get; set; }
        [DataMember] public int discountedPrice { get; set; }
        [DataMember] public int vat { get; set; }
        [DataMember] public int salesTax { get; set; }
        [DataMember] public int paymentProviderFee { get; set; }
        [DataMember] public int paymentMethodFee { get; set; }
        [DataMember] public CurrencySummary currency { get; set; }
        [DataMember] public PaymentUrl paymentUrl { get; set; }
        [DataMember] public string paymentStationUrl { get; set; }
        [DataMember] public OrderTransaction[] transactions { get; set; }
        [DataMember] public string[] entitlementIds { get; set; }
        [DataMember] public string status { get; set; } //['INIT', 'CHARGED', 'CHARGE_FAILED', 'FULFILLED', 'FULFILL_FAILED', 'REFUNDING', 'REFUNDED', 'DELETED'],
        [DataMember] public string statusReason { get; set; }
        [DataMember] public string @namespace { get; set; }
        [DataMember] public DateTime createdTime { get; set; }
        [DataMember] public DateTime chargedTime { get; set; }
        [DataMember] public DateTime fulfilledTime { get; set; }
        [DataMember] public DateTime refundedTime { get; set; }
    }
}