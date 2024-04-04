using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;

public class SpawnAreaCorner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _width = 0;
    [SerializeField] private float _height = 0;
    [SerializeField] private int _spawnCount = 1;

    public SpawnZone SpawnZone { get; private set; }


    void Start()
    {
        Vector2 position = gameObject.transform.position;
        SpawnZone= new SpawnZone(position, _width, _height*-1, _spawnCount);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

    

