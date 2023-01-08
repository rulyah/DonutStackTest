using DG.Tweening;
using UnityEngine;

public class Donut : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private DOTween _doTween;
    public int colorId;
    //public Stick parent;

    public void Move(Stick stick)
    {
        transform.SetParent(stick.transform);
        //transform.DOJump(new Vector3(stick.transform.position.x, GameConfig.instance.donutOffsetY * stick.donuts.Count,
            //stick.transform.position.z), 2.0f, 1, 0.5f);


        //transform.DOFlip();
        stick.AddDonut(this);
    }

    public void SetRandomColor()
    {
        colorId = Random.Range(0, GameConfig.instance.materials.Count);
        _meshRenderer.material = GameConfig.instance.materials[colorId];
    }
}