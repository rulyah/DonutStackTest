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
            Model.currentStick.transform.DOMove(new Vector3(_position.x, 0.0f, _position.z), GameConfig.instance.moveSpeed).
                SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => ChangeState(new CheckCornerSticks(_core)));
        }
    }
}