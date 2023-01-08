using DG.Tweening;
using UnityEngine;

namespace States
{
    public class DestroySticksState : State<Core>
    {
        public DestroySticksState(Core core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("DestroySticksState");
            var stick = Model.sticks.Find(n => n.isNedToDestroy);
            var pos = stick.transform.position;
            Factory.instance.HideStick(stick);
            /*foreach (var stick in Model.sticks.FindAll(n => n.isNedToDestroy))
            {
                var emptyPos = stick.transform.position
                Factory.instance.HideStick(stick);
            }*/
            ChangeState(new MoveColumnState(_core, pos));
        }
    }
}