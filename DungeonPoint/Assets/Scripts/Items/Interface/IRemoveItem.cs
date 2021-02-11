namespace Game.Entitys.Items.Interface
{
    using Game.Player;

    public interface IRemoveItem
    {
        void UnEquip(PlayerStats Player);
    }
}
