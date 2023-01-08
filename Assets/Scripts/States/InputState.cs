using UI;

namespace States
{
    public class InputState : State<Core>
    {
        public InputState(Core core) : base(core) {}

        public override void OnEnter()
        {
            Column.onColumnClick += OnColumnClick;
            GameScreen.onGameRestart += OnGameRestart;
        }

        private void OnGameRestart()
        {
            ChangeState(new RestartGameState(_core));
        }

        private void OnColumnClick(int posX)
        {
            ChangeState(new CheckCanMove(_core, posX));
        }

        public override void OnExit()
        {
            Column.onColumnClick -= OnColumnClick;
            GameScreen.onGameRestart -= OnGameRestart;

        }
    }
}