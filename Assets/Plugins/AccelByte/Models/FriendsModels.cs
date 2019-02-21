// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class ListOutgoingFriends
    {
        [DataMember] public string[] friendsId;
    }

    [DataContract]
    public class ListIncomingFriends
    {
        [DataMember] public string[] friendsId;
    }

    [DataContract]
    public class FriendList
    {
        [DataMember] public string[] friendsId;
    }

    [DataContract]
    public class FriendshipStatus
    {
        [DataMember] public RelationshipStatusCode friendshipStatus;
    }

    [DataContract]
    public class TargetedUserId
    {
        [DataMember] public string friendId;
    }

    [DataContract]
    public class AcceptFriendsNotif
    {
        [DataMember] public string friendId;
    }
    
    [DataContract]
    public class RequestFriendsNotif
    {
        [DataMember] public string friendId;
    }
    
    [DataContract]
    public enum RelationshipStatusCode
    {
        [EnumMember] Friend = 3,
        [EnumMember] Incoming = 2,
        [EnumMember] Outgoing = 1,
        [EnumMember] NotFriend = 0
    }
}