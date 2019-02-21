// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Api
{
    [DataContract]
    public class MessageNotification
    {
        [DataMember] public string id;
        [DataMember] public string from;
        [DataMember] public string to;
        [DataMember] public string topic;
        [DataMember] public string payload;
        [DataMember] public string sentAt;
    }
}