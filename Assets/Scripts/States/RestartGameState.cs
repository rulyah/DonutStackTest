namespace States
{
    public class RestartGameState : State<Core>
    {
        public RestartGameState(Core core) : base(core) {}

        public override void OnEnter()
        {
            /*Model.sticks.Clear();
            Model.checkedSticks.Clear();
            Model.suitableSticks.Clear();*/
            foreach (var stick in Model.sticks)
            {
                Factory.instance.HideStick(stick);
            }
        }
    }
}