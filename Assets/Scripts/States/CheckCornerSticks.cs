using System.Collections.Generic;
using Commands;
using UnityEngine;

namespace States
{
    public class CheckCornerSticks : State<Core>
    {

        //private List<Stick> _suitableSticks;
        //private Stick _first;
        //private Stick _second;
        public CheckCornerSticks(Core core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("CheckCornerSticks");
            while (true)
            {
                Model.firstSuitableStick = FindStickByPriority(3);
                if(Model.firstSuitableStick == null) break;
                Model.secondSuitableStick = FindToMove(Model.firstSuitableStick);
                if(Model.secondSuitableStick != null) break;
            }
            if(Model.firstSuitableStick == null) ChangeState(new CreateStickState(_core));
            if(Model.secondSuitableStick != null) ChangeState(new MoveDonutState(_core));

            /*Model.firstSuitableStick = FindStickByPriority(3);
            if(Model.firstSuitableStick == null) ChangeState(new CreateStickState(_core));
            else
            {
                Model.secondSuitableStick = FindToMove(Model.firstSuitableStick);
                if (Model.secondSuitableStick == null) FindStickByPriority(3);
                else ChangeState(new MoveDonutState(_core, Model.firstSuitableStick, Model.secondSuitableStick));
            }*/
            //if(Model.secondSuitableStick != null) 
            //else ChangeState(new CreateStickState(_core));
        }
        /*public override void OnEnter()
        {
            Debug.Log("CheckCornerSticks");
            //_suitableSticks = new List<Stick>();
            for (var i = 0; i < Model.sticks.Count; i++)
            {
                FindCloserSticks.FindCloser(Model.sticks[i],Model.suitableSticks);
                for (var l = 0; l < Model.suitableSticks.Count; l++)
                {
                    if (Model.suitableSticks[l].priority == 3 && IsCanGetDonut(Model.suitableSticks[l]))
                    {
                        ChangeState(new MoveDonutState(_core, Model.sticks[i], Model.suitableSticks[l]));
                        return;
                    }
                }
            }
            ChangeState(new CreateStickState(_core));
            //if(_suitableSticks.Count == 0) ChangeState(new CreateStickState(_core));
            //else OnEnter();
        }*/

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
                //Debug.Log(Model.checkedSticks.Count.ToString());
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
            //Debug.Log(Model.checkedSticks.Count.ToString());
            //Model.firstSuitableStick = null;
            //FindStickByPriority(3);
            return null;
        }
        
        private bool IsCanGetDonut(Stick stick)
        {
            return stick.donuts.Count < GameConfig.instance.maxDonutCount;
        }

        public override void OnExit()
        {
            Model.checkedSticks.Clear();
        }

        /*
         * 1 - знаходимо сосідні палки
         * 2 - відбір того з ким можна свапнути
         * 3 - вибір по пріорітетах :
         * в порядку зпадання
         * кольори
         * кількість
         * напрямок (з кого куди)
         */
        
        
        //зробити навпака, знайти стік з пріорітетом 3 і від нього відштовхнутись
        
        /*if (_second != null)
                {
                    Model.checkedSticks.Clear();
                    //ChangeState(new MoveDonutState(_core, _first,_second));
                }
                else
                {
                    _second = Model.suitableSticks.Find(n => n.donuts.Count == 1);
                    if (_second != null)
                    {
                        Model.checkedSticks.Clear();
                        //ChangeState(new MoveDonutState(_core, _first,_second));
                    }
                    else
                    {
                        _second = Model.suitableSticks.Find(n => n.donuts.Count == 2);
                        if (_second != null)
                        {
                            Model.checkedSticks.Clear();
                            //ChangeState(new MoveDonutState(_core, _first,_second));
                        }
                        else
                        {
                            Model.checkedSticks.Add(_first);
                            FindStickByPriority(3);
                        }
                    }
                }*/
        
    }
}