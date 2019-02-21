// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class ItemSnapshot
    {
        [DataMember] public string itemId { get; set; }
        [DataMember] public string appId { get; set; }
        [DataMember] public EntitlementAppType appType { get; set; }
        [DataMember] public string sku { get; set; }
        [DataMember] public string @namespace { get;set;}
        [DataMember] public string name { get; set; }
        [DataMember] public int useCount { get; set; }
        [DataMember] public ItemType itemType { get; set; }
        [DataMember] public string targetCurrencyCode { get; set; }
        [DataMember] public string targetNamespace { get; set; }
        [DataMember] public string title { get; set; }
        [DataMember] public Image thumbnailImage { get; set; }
        [DataMember] public RegionData regionDataItem { get; set; }
        [DataMember] public string[] itemIds { get; set; }
        [DataMember] public int maxCountPerUser { get; set; }
        [DataMember] public int maxCount { get; set; }
        [DataMember] public string region { get; set; }
        [DataMember] public string language { get; set; }
    }
}