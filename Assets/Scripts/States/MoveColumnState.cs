using DG.Tweening;
using UnityEngine;

namespace States
{
    public class MoveColumnState : State<Core>
    {
        private Vector3 _position;
        public MoveColumnState(Core core, Vector3 pos) : base(core)
        {
            _position = pos;
        }

        public override void OnEnter()
        {
            Debug.Log("MoveColumnState");
            var sticks = Model.sticks.FindAll(n =>
                n.transform.position.z < _position.z && (int)n.transform.position.x == (int)_position.x);
            if(sticks.Count == 0) ChangeState(new CheckToDestroyStickState(_core));
            else
            {
                foreach (var stick in sticks)
                {
                    stick.transform.DOMoveZ(stick.transform.position.z + 1, GameConfig.instance.moveSpeed)
                        .SetSpeedBased().SetEase(Ease.Linear)
                        .OnComplete(() => ChangeState(new CheckToDestroyStickState(_core)));
                }
            }
        }
    }
}