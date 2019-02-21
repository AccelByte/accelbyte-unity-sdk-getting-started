// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Price
    {
        [DataMember] public int value { get; set; }
        [DataMember] public string currencyCode { get; set; }
        [DataMember] public string currencyType { get; set; }
        [DataMember] public string @namespace { get; set; }
    }
}