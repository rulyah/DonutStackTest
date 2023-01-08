using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace States
{
    public class MoveDonutState : State<Core>
    {
        public MoveDonutState(Core core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("MoveDonutState");
            Model.secondSuitableStick.donuts[^1].transform.DOJump(new Vector3(Model.firstSuitableStick.transform.position.x, 
                GameConfig.instance.donutOffsetY * Model.firstSuitableStick.donuts.Count, 
                Model.firstSuitableStick.transform.position.z), 2.0f, 1, 0.5f).OnComplete(() =>
            {
                Model.secondSuitableStick.MoveDonut(Model.firstSuitableStick);
                ChangeState(new CheckToDestroyStickState(_core));
                //if (Model.sticks.Any(n => n.isNedToDestroy)) ChangeState(new DestroySticksState(_core));
                //else ChangeState(new CheckCornerSticks(_core));
            });
        }
    }
}