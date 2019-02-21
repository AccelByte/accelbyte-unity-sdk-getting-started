// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Api
{
    [DataContract]
    public class KickNotification
    {
        [DataMember] public string leaderID;
        [DataMember] public string userID;
        [DataMember] public string partyID;
    }
}