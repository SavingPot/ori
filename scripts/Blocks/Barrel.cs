using GameCore.UI;

namespace GameCore
{
    public class Barrel : StorageBlock
    {
        public static BackpackPanel staticItemPanel;
        public static ScrollViewIdentity staticItemView;
        public static InventorySlotUI[] staticSlotUIs = new InventorySlotUI[defaultItemCountConst];
        public const int defaultItemCountConst = 4 * 7;
        public override int itemCount => defaultItemCountConst;
        public override string backpackPanelId => "ori:barrel";
        public override BackpackPanel itemPanel { get => staticItemPanel; set => staticItemPanel = value; }
        public override ScrollViewIdentity itemView { get => staticItemView; set => staticItemView = value; }
        public override InventorySlotUI[] slotUIs { get => staticSlotUIs; set => staticSlotUIs = value; }
    }
}