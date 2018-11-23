using System;

namespace Assets.Scripts.Scripts_Old
{
    public class ItemStack
    {
        private Type item;
        private int amount;
        

        public ItemStack(Type obj)
        {
            this.item = obj;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public void AddAmount(int amount)
        {
            //if()
            this.amount += amount;
        }
    }
}
