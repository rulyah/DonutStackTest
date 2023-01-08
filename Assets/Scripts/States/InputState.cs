using UnityEngine;

namespace States
{
    public class InputState : State<Core>
    {
        public InputState(Core core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("InputState");
            Column.onColumnClick += OnColumnClick;
        }

        private void OnColumnClick(int posX)
        {
            ChangeState(new CheckCanMove(_core, posX));
        }

        public override void OnExit()
        {
            Column.onColumnClick -= OnColumnClick;
        }
    }
}