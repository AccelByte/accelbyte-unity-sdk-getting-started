// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for EntitlementClazz
    public sealed class EntitlementClazz
    {
        private readonly string name;

        public static readonly EntitlementClazz App = new EntitlementClazz("APP");
        public static readonly EntitlementClazz Entitlement = new EntitlementClazz("ENTITLEMENT");
        public static readonly EntitlementClazz Distribution = new EntitlementClazz("DISTRIBUTION");
        public static readonly EntitlementClazz Code = new EntitlementClazz("CODE");

        private EntitlementClazz(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
