// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class TokenData
    {
        [DataMember] public string access_token { get; set; }
        [DataMember] public string refresh_token { get; set; }
        [DataMember] public int expires_in { get; set; }
        [DataMember] public string token_type { get; set; }
        [DataMember] public string user_id { get; set; }
        [DataMember] public string display_name { get; set; }
        [DataMember] public string @namespace { get; set; }
    }
}