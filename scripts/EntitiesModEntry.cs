﻿using UnityEngine;
using SP.Tools.Unity;

namespace GameCore
{
    public class EntitiesModEntry : ModEntry
    {
        public override void OnLoaded()
        {
            base.OnLoaded();



            //让玩家穿着羽翼时重力降低
            Player.GravitySet += caller =>
            {
                if (caller.inventory.breastplate?.data?.id == ItemID.FeatherWing)
                {
                    caller.gravity *= 0.7f;
                }
            };

            //注册玩家的远程命令
            //注意：以后可能得为所有 Entity 都注册，毕竟 Entity 以后可能也可以使用魔法
            PlayerCenter.OnAddPlayer += player =>
            {
                player.RegisterParamRemoteCommand(LaserSpellBehaviour.LaserLightCommandId, LaserSpellBehaviour.LaserLight);
            };



            //注册水物理
            GM.OnUpdate += WaterCenter.WaterPhysics;



            //绑定场景切换事件
            GScene.AfterChanged += scene =>
            {
                //清理对象池
                LaserLightPool.stack.Clear();

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
