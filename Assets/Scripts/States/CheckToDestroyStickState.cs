using System.Linq;
using UnityEngine;

namespace States
{
    public class CheckToDestroyStickState : State<Core>
    {
        public CheckToDestroyStickState(Core core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("CheckToDestroyStickState");
            if (Model.sticks.Any(n => n.isNedToDestroy)) ChangeState(new DestroySticksState(_core));
            else ChangeState(new CheckCornerSticks(_core));
        }
    }
}