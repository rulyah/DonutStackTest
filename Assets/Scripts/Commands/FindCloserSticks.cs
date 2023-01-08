using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public static class FindCloserSticks
    {
        public static void FindCloser(Stick stick, List<Stick> sticks)
        {
            if(sticks.Count > 0) sticks.Clear();
            for (var i = 0; i < Model.sticks.Count; i++)
            {
                var distance = Vector3.Distance(stick.transform.position, Model.sticks[i].transform.position);
                if(distance == 0.0f) continue;
                if(distance <= GameConfig.instance.maxDistance && 
                   Model.sticks[i].donuts[^1].colorId == stick.donuts[^1].colorId) sticks.Add(Model.sticks[i]);
            }
        }
    }
}