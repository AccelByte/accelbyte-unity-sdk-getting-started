// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class ItemCriteria
    {
        [DataMember] public ItemType ItemType { get; set; }
        [DataMember] public string CategoryPath { get; set; }
        [DataMember] public ItemStatus ItemStatus { get; set; }
        [DataMember] public int? Page { get; set; }
        [DataMember] public int? Size { get; set; }
    }
}