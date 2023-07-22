using UnityEngine;

namespace GameCore
{
    [NotSummonable]
    public abstract class BiomeGuard : Creature
    {
        public ParticleSystem particleSystem;
        public BiomeGuardParticle particleScript;

        protected override void Start()
        {
            base.Start();

            //TODO: pool-ify
            particleSystem = GameObject.Instantiate(GInit.instance.BiomeGuardParticleSystemPrefab);
            particleSystem.transform.position = transform.position;
            particleSystem.textureSheetAnimation.AddSprite(ModFactory.CompareTexture("ori:biome_guard_particle").sprite);
            particleSystem.gameObject.AddComponent<BiomeGuardParticle>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}