// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class OrderTransaction
    {
        [DataMember] public string txId { get; set; } //,
        [DataMember] public int amount { get; set; } //,
        [DataMember] public int vat { get; set; }
        [DataMember] public int salesTax { get; set; }
        [DataMember] public CurrencySummary currency { get; set; } //,
        [DataMember] public string type { get; set; } // = ['CHARGE', 'REFUND'],
        [DataMember] public string status { get; set; } // = ['INIT', 'FINISHED', 'FAILED'],
        [DataMember] public string provider { get; set; } // = ['XSOLLA', 'WALLET'],
        [DataMember] public int paymentProviderFee { get; set; }
        [DataMember] public string paymentMethod { get; set; } //,
        [DataMember] public int paymentMethodFee { get; set; }
        [DataMember] public string merchantId { get; set; } //,
        [DataMember] public string extTxId { get; set; } //,
        [DataMember] public string extStatusCode { get; set; } //,
        [DataMember] public string extMessage { get; set; } //,
        [DataMember] public string txStartTime { get; set; } //,
        [DataMember] public string txEndTime { get; set; } //
    }
}