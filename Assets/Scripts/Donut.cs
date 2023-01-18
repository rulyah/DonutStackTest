using UnityEngine;

public class Donut : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public int colorId;

    public void Move(Stick stick)
    {
        transform.SetParent(stick.transform);
        stick.AddDonut(this);
    }

    public void SetRandomColor()
    {
        colorId = Random.Range(0, GameConfig.instance.materials.Count);
        _meshRenderer.material = GameConfig.instance.materials[colorId];
    }
}