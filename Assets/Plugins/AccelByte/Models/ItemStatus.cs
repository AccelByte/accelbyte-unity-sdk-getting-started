// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for ItemStatus
    public sealed class ItemStatus
    {
        private readonly string name;

        public static readonly ItemStatus Active = new ItemStatus("ACTIVE");
        public static readonly ItemStatus Inactive = new ItemStatus("INACTIVE");
        public static readonly ItemStatus Deleted = new ItemStatus("DELETED");

        private ItemStatus(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
