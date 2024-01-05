using System.Collections;
using SP.Tools.Unity;
using UnityEngine;
using static GameCore.UniversalEntityBehaviour;

namespace GameCore
{
    //TODO: Complete
    [EntityBinding(EntityID.Savage)]
    public class Savage : Enemy
    {
        public EnemyMoveToTarget ai;
        public bool isPursuing;
        public bool isPursuingLastFrame;



        protected override void Awake()
        {
            base.Awake();

            ai = new(this, 45);
        }

        protected override void Start()
        {
            base.Start();

            MethodAgent.TryRun(() =>
            {
                //添加身体部分
                body = AddBodyPart("body", ModFactory.CompareTexture("ori:zombie_body").sprite, Vector2.zero, 5, model.transform, BodyPartType.Body);
                head = AddBodyPart("head", ModFactory.CompareTexture("ori:zombie_head").sprite, new(-0.02f, -0.03f), 10, body, BodyPartType.Head, new(-0.03f, -0.04f));
                rightArm = AddBodyPart("rightArm", ModFactory.CompareTexture("ori:zombie_right_arm").sprite, new(0, 0.03f), 8, body, BodyPartType.RightArm);
                leftArm = AddBodyPart("leftArm", ModFactory.CompareTexture("ori:zombie_left_arm").sprite, new(0, 0.03f), 3, body, BodyPartType.LeftArm);
                rightLeg = AddBodyPart("rightLeg", ModFactory.CompareTexture("ori:zombie_right_leg").sprite, new(0.02f, 0.04f), 3, body, BodyPartType.RightLeg);
                leftLeg = AddBodyPart("leftLeg", ModFactory.CompareTexture("ori:zombie_left_leg").sprite, new(-0.02f, 0.04f), 1, body, BodyPartType.LeftLeg);
                rightFoot = AddBodyPart("rightFoot", ModFactory.CompareTexture("ori:zombie_right_foot").sprite, Vector2.zero, 3, rightLeg, BodyPartType.RightFoot);
                leftFoot = AddBodyPart("leftFoot", ModFactory.CompareTexture("ori:zombie_left_foot").sprite, Vector2.zero, 1, leftLeg, BodyPartType.LeftFoot);
            }, true);


            Creature.BindHumanAnimations(this);
        }

        public override void Movement()
        {
            base.Movement();

            if (!isServer || isDead)
                return;

            isPursuing = targetTransform;

            if (isPursuing)
            {
                if (!isPursuingLastFrame)
                {
                    OnStartMovementAction();
                }

                ai.Pursuit();
            }
            else
            {
                if (isPursuingLastFrame)
                {
                    OnStopMovementAction();

                    rb.velocity = Vector2.zero;
                }

                ai.Stroll();
            }

            isPursuingLastFrame = isPursuing;
        }
    }
}