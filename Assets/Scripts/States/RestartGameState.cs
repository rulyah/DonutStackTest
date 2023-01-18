namespace States
{
    public class RestartGameState : State<Core>
    {
        public RestartGameState(Core core) : base(core) {}

        public override void OnEnter()
        {
            foreach (var stick in Model.sticks)
            {
                Factory.instance.HideStick(stick);
            }
        }
    }
}