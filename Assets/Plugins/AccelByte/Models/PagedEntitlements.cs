// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class PagedEntitlements
    {
        [DataMember] public Entitlement[] data { get; set; }
        [DataMember] public Paging paging { get; set; }
    }
}