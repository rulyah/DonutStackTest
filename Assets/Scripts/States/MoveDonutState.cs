using DG.Tweening;
using UnityEngine;

namespace States
{
    public class MoveDonutState : State<Core>
    {
        public MoveDonutState(Core core) : base(core) {}

        public override void OnEnter()
        {
            SetDirection(Model.firstSuitableStick, Model.secondSuitableStick);
        }

        private void SetDirection(Stick first, Stick second)
        {
            if (first.priority == 3)
            {
                PlayJump(second, first);
            }

            if (first.priority == 2)
            {
                if(second.donuts.Count < 3) PlayJump(first, second);
                else PlayJump(second, first);
            }

            if (first.priority == 1)
            {
                if(second.priority is 3 or 2) PlayJump(first,second);
                else PlayJump(second, first);
            }

            if (first.priority == 0)
            {
                PlayJump(first, second);
            }
        }

        private void PlayJump(Stick firstStick, Stick secondStick)
        {
            //Model.lastMoveFirstStick = firstStick;
            //Model.lastMoveSecondStick = secondStick;
            //firstStick.isUsed = true;
            //secondStick.isUsed = true;
            //firstStick.donuts[^1].transform.DOLocalRotate(new Vector3())

            //firstStick.donuts[^1].transform.DORotate(new Vector3(-450.0f, 0.0f), 0.5f);
            firstStick.donuts[^1].transform.DORotate(new Vector3(firstStick.donuts[^1].transform.rotation.x + 360.0f,
                0.0f,0.0f), 0.4f, RotateMode.FastBeyond360);
            firstStick.donuts[^1].transform.DOJump(new Vector3(secondStick.transform.position.x, 
                GameConfig.instance.firsDonutPosY + GameConfig.instance.donutOffsetY * secondStick.donuts.Count, 
                secondStick.transform.position.z), 2.0f, 1, 0.5f).OnComplete(() =>
            {
                firstStick.MoveDonut(secondStick);
                ChangeState(new CheckToDestroyStickState(_core));
            });
        }
    }
}