﻿namespace GameCore
{
    public class EntitiesModEntry : ModEntry
    {
        public override void OnLoaded()
        {
            base.OnLoaded();

            Player.GravitySet += caller =>
            {
                if (caller.inventory.HasItem(ItemID.FeatherWing))
                {
                    caller.gravity *= 0.75f;
                }
            };

            Player.backpackSidebarTable.Add("ori:barrel", (() => { BarrelBlockBehaviour.GenerateItemView().gameObject.SetActive(true); }, () => { BarrelBlockBehaviour.GenerateItemView().gameObject.SetActive(false); }));
            Player.backpackSidebarTable.Add("ori:cooking_pot", (() => { CookingPotBlockBehaviour.GenerateItemView().gameObject.SetActive(true); }, () => { CookingPotBlockBehaviour.GenerateItemView().gameObject.SetActive(false); }));
            Player.backpackSidebarTable.Add("ori:soft_clay_furnace", (() => { SoftClayFurnace.GenerateItemView().gameObject.SetActive(true); }, () => { SoftClayFurnace.GenerateItemView().gameObject.SetActive(false); }));
            Player.backpackSidebarTable.Add("ori:wooden_chest", (() => { WoodenChest.GenerateItemView().gameObject.SetActive(true); }, () => { WoodenChest.GenerateItemView().gameObject.SetActive(false); }));
            //Player.backpackSidebarTable.Add("ori:wooden_bowl_with_water", (() => { WoodenBowlWithWaterBehaviour.GenerateItemView().gameObject.SetActive(true); }, () => { WoodenBowlWithWaterBehaviour.GenerateItemView().gameObject.SetActive(false); }));

            GScene.AfterChanged += scene =>
            {
                switch (scene.name)
                {
                    //TODO: 调整音频播放位置
                    case SceneNames.MainMenu:
                        GAudio.Play(AudioID.Town);
                        GAudio.Stop(AudioID.WhyNotComeToTheParty);
                        break;

                    case SceneNames.GameScene:
                        GAudio.Stop(AudioID.Town);
                        GAudio.Play(AudioID.WhyNotComeToTheParty);
                        break;
                }
            };
        }
    }
}
