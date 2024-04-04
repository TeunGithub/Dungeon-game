using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnHandler : MonoBehaviour
{
    private List<SpawnZone> _spawnZones;
    private const float SPAWN_DELAY = 10;
    private float _spawnTimer = 0;
   
    // Start is called before the first frame update
    void Start()
    {
      
        _spawnZones = new List<SpawnZone>();
        GameObject[] SpawnCorners = GameObject.FindGameObjectsWithTag("SpawnAreaPosition");
        
        foreach (GameObject gameObject in SpawnCorners)
        {
            SpawnAreaCorner spawnArea = gameObject.GetComponent<SpawnAreaCorner>();
            spawnArea.SpawnZone.SpawnEntities();
            _spawnZones.Add(spawnArea.SpawnZone);
        }


    }
    
    void Update()
    {
        if(_spawnTimer > SPAWN_DELAY)
        {
            foreach (SpawnZone spawnZone in _spawnZones)
            {
                spawnZone.SpawnEntities();
            }
            _spawnTimer = 0;
        }
        _spawnTimer += Time.deltaTime;

    }
}
