using System.Collections.Generic;
using ToonyColorsPro.ShaderGenerator;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Donut _donutPrefab;
    [SerializeField] private Stick _stickPrefab;

    private List<Donut> _hiddenDonuts;
    private List<Stick> _hiddenSticks;
    public static Factory instance { get; private set; }

    private void Awake()
    {
        instance = this;
        _hiddenDonuts = new List<Donut>();
        _hiddenSticks = new List<Stick>();
    }

    public Donut GetDonut()
    {
        if (_hiddenDonuts.Count > 0)
        {
            var donut = _hiddenDonuts[0];
            _hiddenDonuts.Remove(donut);
            donut.gameObject.SetActive(true);
            return donut;
        }
        else
        {
            var donut = Instantiate(_donutPrefab);
            donut.SetRandomColor();
            return donut;
        }
    }

    public void HideDonut(Donut donut)
    {
        _hiddenDonuts.Add(donut);
        donut.gameObject.SetActive(false);
    }

    public Stick GetStick()
    {
        if (_hiddenSticks.Count > 0)
        {
            var stick = _hiddenSticks[0];
            _hiddenSticks.Remove(stick);
            stick.gameObject.SetActive(true);
            return stick;
        }
        else return Instantiate(_stickPrefab);
    }

    public void HideStick(Stick stick)
    {
        Model.sticks.Remove(stick);
        _hiddenSticks.Add(stick);
        stick.gameObject.SetActive(false);
    }
}