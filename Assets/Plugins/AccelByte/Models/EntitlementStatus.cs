// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for EntitlementStatus
    public sealed class EntitlementStatus
    {
        private readonly string name;

        public static readonly EntitlementStatus Active = new EntitlementStatus("ACTIVE");
        public static readonly EntitlementStatus Inactive = new EntitlementStatus("INACTIVE");
        public static readonly EntitlementStatus Distributed = new EntitlementStatus("DISTRIBUTED");
        public static readonly EntitlementStatus Revoked = new EntitlementStatus("REVOKED");
        public static readonly EntitlementStatus Deleted = new EntitlementStatus("DELETED");

        private EntitlementStatus(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
