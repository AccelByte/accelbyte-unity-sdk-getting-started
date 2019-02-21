// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for EntitlementType
    public sealed class EntitlementType
    {
        private readonly string name;

        public static readonly EntitlementType Durable = new EntitlementType("DURABLE");
        public static readonly EntitlementType Consumable = new EntitlementType("CONSUMABLE");

        private EntitlementType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
