using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    
    public static GameConfig instance { get; private set; }

    public List<Material> materials;
    public int maxDonutCount = 3;
    public Vector3 spawnPoint = new (0.0f, 0.0f, -4.0f);
    public float donutOffsetY = 0.333f;
    public float firsDonutPosY = 0.19f;
    public float moveSpeed = 7.0f;
    public float maxDistance = 1.0f;
    
    private void Awake()
    {
        instance = this;
    }
}