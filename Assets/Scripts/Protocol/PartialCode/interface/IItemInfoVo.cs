namespace SmalBox
{
    public interface IItemInfoVo
    {
        void ParseData(ItemInfo itemInfo);

        ItemType GetItemType();

        int GetIableType();

        int GetId();

        int GetNum();
    }
}