using Assets.Scripts.Common;

namespace Assets.Scripts.Scripts_Old
{
    public interface IInventory
    {
        void Add(ItemStack item, int position);

        ItemStack Remove(int amount, int position);
    }
}
