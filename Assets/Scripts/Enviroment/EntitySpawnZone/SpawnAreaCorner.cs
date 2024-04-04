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

    public float Width { get { return _width; } }
    public float Height {  get { return _height * -1; } }
    public Vector2 Position { get; private set; }

    void Start()
    {
        Position = gameObject.transform.position;
        Debug.Log(Position.ToString());
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

    

