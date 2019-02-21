// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Item
    {
        [DataMember] public string title { get; set; }
        [DataMember] public string description { get; set; }
        [DataMember] public string longDescription { get; set; }
        [DataMember] public Image[] images { get; set; }
        [DataMember] public Image thumbnailImage { get; set; }
        [DataMember] public string itemId { get; set; }
        [DataMember] public string appId { get; set; }
        [DataMember] public string appType { get; set; }    //"GAME"
        [DataMember] public string sku { get; set; }
        [DataMember] public string @namespace { get; set; }
        [DataMember] public string entitlementName { get; set; }
        [DataMember] public string entitlementType { get; set; }
        [DataMember] public int useCount { get; set; }
        [DataMember] public string categoryPath { get; set; }
        [DataMember] public string status { get; set; }
        [DataMember] public string itemType { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
        [DataMember] public string targetCurrencyCode { get; set; }
        [DataMember] public RegionData[] regionData { get; set; }
        [DataMember] public string[] itemIds { get; set; }
        [DataMember] public string[] tags { get; set; }
    }
}