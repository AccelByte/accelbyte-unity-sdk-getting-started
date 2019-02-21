// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Entitlement
    {
        [DataMember] public string id { get; set; }
        [DataMember] public string @namespace { get; set; }
        [DataMember] public string clazz { get; set; }
        [DataMember] public string type { get; set; }
        [DataMember] public string status { get; set; }
        [DataMember] public string appId { get; set; }
        [DataMember] public string appType { get; set; }
        [DataMember] public string sku { get; set; }
        [DataMember] public string userId { get; set; }
        [DataMember] public string itemId { get; set; }
        [DataMember] public string bundleItemId { get; set; }
        [DataMember] public string grantedCode { get; set; }
        [DataMember] public string itemNamespace { get; set; }
        [DataMember] public string name { get; set; }
        [DataMember] public int useCount { get; set; }
        [DataMember] public int quantity { get; set; }
        [DataMember] public int distributedQuantity { get; set; }
        [DataMember] public string targetNamespace { get; set; }
        [DataMember] public ItemSnapshot itemSnapshot { get; set; }
        [DataMember] public DateTime startDate { get; set; }
        [DataMember] public DateTime endDate { get; set; }
        [DataMember] public DateTime grantedAt { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }     
    }
}
