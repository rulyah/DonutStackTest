using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CreateStickState : State<Core>
    {
        public CreateStickState(Core core) : base(core) {}

        public override void OnEnter()
        {
            var stick = Factory.instance.GetStick();
            stick.donuts = new List<Donut>();
            Model.sticks.Add(stick);
            stick.transform.position = GameConfig.instance.spawnPoint;
            var donutsCount = Random.Range(1, GameConfig.instance.maxDonutCount + 1);
            for (var i = 0; i < donutsCount; i++)
            {
                var donut = Factory.instance.GetDonut();
                donut.transform.SetParent(stick.transform);
                donut.transform.localPosition = new Vector3(0.0f, 
                    GameConfig.instance.firsDonutPosY + GameConfig.instance.donutOffsetY * stick.donuts.Count, 0.0f);
                stick.AddDonut(donut);
            }
            while (true)
            {
                if (CheckToOneColorFull(stick)) ChangeDonutsColor(stick);
                else break;
            }
            stick.Init();
            ChangeState(new InputState(_core));
        }

        private bool CheckToOneColorFull(Stick stick)
        {
            return stick.donuts.FindAll(n => n.colorId == stick.donuts[^1].colorId).Count == 3;
        }

        private void ChangeDonutsColor(Stick stick)
        {
            for (var i = 0; i < stick.donuts.Count; i++)
            {
                stick.donuts[i].SetRandomColor();
            }
        }
    }
}