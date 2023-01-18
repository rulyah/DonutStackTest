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
                if (Model.secondSuitableStick != null && IsMaceSense(Model.firstSuitableStick, Model.secondSuitableStick)) break;
                Model.checkedSticks.Add(Model.firstSuitableStick);
                Model.secondSuitableStick = null;
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

        private bool IsMaceSense(Stick first, Stick second)
        {
            if (first.priority is 3 or 2 || second.priority is 3 or 2) return true;
            if (first.priority == 1)
            {
                if (second.priority == 1) return true;
                return second.donuts[^2].colorId != second.donuts[^1].colorId;
            }
            if (second.priority == 1)
            {
                if (first.priority == 1) return true;
                return first.donuts[^2].colorId != first.donuts[^1].colorId;
            }
            return true;
        }

        public override void OnExit()
        {
            Model.checkedSticks.Clear();
        }
    }
}