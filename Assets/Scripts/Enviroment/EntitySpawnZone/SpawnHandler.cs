using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnHandler : MonoBehaviour
{
    private List<SpawnZone> _spawnZones;

   
    // Start is called before the first frame update
    void Start()
    {
      
        _spawnZones = new List<SpawnZone>();
        GameObject[] SpawnCorners = GameObject.FindGameObjectsWithTag("SpawnAreaPosition");
        
        foreach (GameObject gameObject in SpawnCorners)
        {
            SpawnAreaCorner spawnArea = gameObject.GetComponent<SpawnAreaCorner>();
            Debug.Log("Getting position");
            _spawnZones.Add(new SpawnZone(spawnArea.Position, spawnArea.Width, spawnArea.Height, 5));

        }
        //World world = GameObject.Find("World").GetComponent<World>();
        //world.Subscribe(this);


    }
    
    void Update()
    {
        foreach (SpawnZone spawnZone in _spawnZones)
        {
            spawnZone.SpawnEntity();
        }
    }
}
