using DG.Tweening;
using UnityEngine;

namespace States
{
    public class MoveHorizontalState : State<Core>
    {
        private Vector3 _position;
        
        public MoveHorizontalState(Core core, Vector3 position) : base(core)
        {
            _position = position;
        }
        
        public override void OnEnter()
        {
            Model.currentStick.transform.DOMove(new Vector3(_position.x, 0.0f, -3.0f), GameConfig.instance.moveSpeed).
                SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => ChangeState(new MoveVerticalState(_core, _position)));
        }
    }
}