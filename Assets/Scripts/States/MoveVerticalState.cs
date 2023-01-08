using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace States
{
    public class MoveVerticalState : State<Core>
    {
        private Vector3 _position;
        public MoveVerticalState(Core core, Vector3 pos) : base(core)
        {
            _position = pos;
        }

        public override void OnEnter()
        {
            Debug.Log("MoveVerticalState");
            Model.currentStick.transform.DOMove(new Vector3(_position.x, 0.0f, _position.z), GameConfig.instance.moveSpeed).
                SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => ChangeState(new CheckCornerSticks(_core)));

            /*foreach (var stick in Model.sticks.FindAll(n => n.transform.position.z < 3))
            {
                var next = Model.sticks.Find(n => (int)n.transform.position.z == (int)stick.transform.position.z + 1);
                if (next == null)
                {
                    stick.transform.DOMoveZ(stick.transform.position.z + 1, GameConfig.instance.moveSpeed).
                        SetSpeedBased().SetEase(Ease.Linear);
                }
            }*/
        }
    }
}