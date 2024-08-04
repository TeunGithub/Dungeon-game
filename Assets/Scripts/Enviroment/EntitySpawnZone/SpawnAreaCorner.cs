using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;

public class SpawnAreaCorner : MonoBehaviour
{

    [SerializeField] private float _width = 0;
    [SerializeField] private float _height = 0;
    [SerializeField] private int _spawnCount = 1;
    

    public float Width { get { return _width; } }
    public float Height { get { return _height; } }
    public int SpawnCount { get { return _spawnCount; } }

    public Vector2 Position { get { return transform.position; } }

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

    

