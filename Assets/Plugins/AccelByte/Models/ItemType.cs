// Copyright (c) 2018-2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Models
{
    //Type-safe enum for ItemType
    public sealed class ItemType
    {
        private readonly string name;

        public static readonly ItemType Product = new ItemType("PRODUCT");
        public static readonly ItemType Coins = new ItemType("COINS");
        public static readonly ItemType InGameItem = new ItemType("INGAMEITEM");
        public static readonly ItemType Bundle = new ItemType("BUNDLE");
        public static readonly ItemType App = new ItemType("APP");
        public static readonly ItemType Code = new ItemType("CODE");


        private ItemType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}