// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class MatchmakingNotif
    {
        [DataMember] public string status;
        [DataMember] public string matchId;
        [DataMember] public string[] partyMember;
        [DataMember] public string[] counterPartyMember;
    }
}
