// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for EntitlementAppType
    public sealed class EntitlementAppType
    {
        private readonly string name;

        public static readonly EntitlementAppType Game = new EntitlementAppType("GAME");
        public static readonly EntitlementAppType Software = new EntitlementAppType("SOFTWARE");
        public static readonly EntitlementAppType DLC = new EntitlementAppType("DLC");
        public static readonly EntitlementAppType Demo = new EntitlementAppType("DEMO");

        private EntitlementAppType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
