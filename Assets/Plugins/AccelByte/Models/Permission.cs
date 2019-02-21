// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Permission
    {
        [DataMember] public string Resource { get; set; }
        [DataMember] public int Action { get; set; }
        [DataMember] public int ShedAction { get; set; }
        [DataMember] public string ShedCron { get; set; }
        [DataMember] public string[] ShedRange { get; set; }
    }
}