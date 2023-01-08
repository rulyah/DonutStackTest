using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public List<Donut> donuts;
    public int priority;
    public bool isNedToDestroy = false;

    public void AddDonut(Donut donut)
    {
            donut.transform.SetParent(transform);
            donuts.Add(donut);
            SetPriority();
    }

    public void MoveDonut(Stick stick)
    {
        var donut = donuts[^1];
        donuts.Remove(donut);
        donut.Move(stick);
        SetPriority();
        if (donuts.Count == 0)
        {
            isNedToDestroy = true;
        }
    }

    public void Disappear()
    {
        StartCoroutine(Delay(0.5f, () =>
        {
            priority = 0;
            Factory.instance.HideStick(this);
        }));
    }

    private void SetPriority()
    {
        if(donuts.Count == 3) priority = 0;
        if (donuts.Count == 2 && donuts[0].colorId == donuts[1].colorId) priority = 3;
        if (donuts.Count == 1) priority = 2;
        if (donuts.Count == 2 && donuts[0].colorId != donuts[1].colorId) priority = 1;
        if (donuts.Count == 3 && donuts[0].colorId == donuts[1].colorId && 
            donuts[1].colorId == donuts[2].colorId) isNedToDestroy = true;
    }

    public void Init()
    {
        //donuts = new List<Donut>();
        SetPriority();
        isNedToDestroy = false;
    }
    
    private IEnumerator Delay(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action?.Invoke();
    }
}