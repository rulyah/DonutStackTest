using UnityEngine;

namespace States
{
    public class CheckCanMove : State<Core>
    {
        private int _columnPos;
        public CheckCanMove(Core core, int column) : base(core)
        {
            _columnPos = column;
        }

        public override void OnEnter()
        {
            var position = FindEmptyPos(_columnPos, 3);
            if(position.z < -3) ChangeState(new InputState(_core));
            else if(position.x == 0) ChangeState(new MoveVerticalState(_core, position));
            else ChangeState(new MoveHorizontalState(_core, position));
        }
        
        private Vector3 FindEmptyPos(int posX, int posZ)
        {
            var stick = Model.sticks.Find(n => (int)n.transform.position.z == posZ &&
                                               (int)n.transform.position.x == posX);
            if (stick == null) return new Vector3(posX, 0.0f, posZ);
            return FindEmptyPos(posX, posZ - 1);
        }
    }
}