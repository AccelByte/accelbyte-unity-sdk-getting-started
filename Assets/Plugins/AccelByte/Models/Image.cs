// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class Image
    {
        [DataMember] public int height { get; set; }
        [DataMember] public int width { get; set; }
        [DataMember] public string imageUrl { get; set; }
        [DataMember] public string smallImageUrl { get; set; }
    }
}