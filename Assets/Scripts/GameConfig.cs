using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    
    public static GameConfig instance { get; private set; }

    public List<Material> materials;
    public int maxDonutCount = 3;
    public Vector3 spawnPoint = new Vector3(0.0f, 0.0f, -4.0f);
    public float donutOffsetY = 0.34f;
    public float moveSpeed = 5.0f;
    public float maxDistance = 1.5f;
    
    private void Awake()
    {
        instance = this;
    }
}