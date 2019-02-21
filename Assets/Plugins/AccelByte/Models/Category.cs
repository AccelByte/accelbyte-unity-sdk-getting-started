// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Category
    {
        [DataMember] public string @namespace { get; set; }
        [DataMember] public string parentCategoryPath { get; set; }
        [DataMember] public string categoryPath { get; set; }
        [DataMember] public string displayName { get; set; }
        [DataMember] public Category[] childCategories { get; set; }
        [DataMember] public DateTime createdAt { get; set; }
        [DataMember] public DateTime updatedAt { get; set; }
        [DataMember] public bool root { get; set; }
    }
}