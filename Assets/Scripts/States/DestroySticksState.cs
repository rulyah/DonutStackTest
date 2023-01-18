using System;

namespace States
{
    public class DestroySticksState : State<Core>
    {
        public DestroySticksState(Core core) : base(core) {}

        public static event Action<int> onScoreChange;

        public override void OnEnter()
        {
            var stick = Model.sticks.Find(n => n.isNedToDestroy);
            var pos = stick.transform.position;
            onScoreChange?.Invoke(ScoreCalculated(stick));
            Factory.instance.HideStick(stick);
            ChangeState(new MoveColumnState(_core, pos));
        }

        private int ScoreCalculated(Stick stick)
        {
            var result = 50;
            for (var i = 0; i < stick.donuts.Count; i++)
            {
                result += 25;
            }
            return result;
        }
    }
}