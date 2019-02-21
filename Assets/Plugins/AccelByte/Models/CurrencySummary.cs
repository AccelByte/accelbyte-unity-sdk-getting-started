// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class CurrencySummary
    {
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string currencySymbol { get; set; }
        [DataMember] public string currencyType { get; set; } // = ['REAL', 'VIRTUAL'],
        [DataMember] public string @namespace { get; set; }
        [DataMember] public int decimals { get; set; }
    }
}