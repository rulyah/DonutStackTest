using Commands;

namespace States
{
    public class CheckCornerSticks : State<Core>
    {
        public CheckCornerSticks(Core core) : base(core) {}

        public override void OnEnter()
        {
            while (true)
            {
                Model.firstSuitableStick = FindStickByPriority(3);
                if(Model.firstSuitableStick == null) break;
                Model.secondSuitableStick = FindToMove(Model.firstSuitableStick);
                if(Model.secondSuitableStick != null) break;
            }
            if(Model.firstSuitableStick == null) ChangeState(new CreateStickState(_core));
            if(Model.secondSuitableStick != null) ChangeState(new MoveDonutState(_core));
        }

        private Stick FindStickByPriority(int priority)
        {
            if (priority == 0) return null;
            if (Model.checkedSticks.Count == Model.sticks.Count) return null;
            var stick = Model.sticks.Find(n => n.priority == priority && Model.checkedSticks.Contains(n) == false);
            return stick == null ? FindStickByPriority(priority - 1) : stick;
        }

        private Stick FindToMove(Stick stick)
        {
            FindCloserSticks.FindCloser(stick, Model.suitableSticks);
            if (Model.suitableSticks.Count <= 0)
            {
                Model.checkedSticks.Add(Model.firstSuitableStick);
                return null;
            }
            var secondStick = Model.suitableSticks.Find(n => n.priority == 2);
            if (secondStick != null) return secondStick;
            secondStick = Model.suitableSticks.Find(n => n.priority == 1);
            if (secondStick != null) return secondStick;
            secondStick = Model.suitableSticks.Find(n => n.priority == 3);
            if (secondStick != null) return secondStick;
            secondStick = Model.suitableSticks.Find(n => n.priority == 0);
            if (secondStick != null) return secondStick;
            Model.checkedSticks.Add(Model.firstSuitableStick);
            return null;
        }
        
        public override void OnExit()
        {
            Model.checkedSticks.Clear();
        }
    }
}