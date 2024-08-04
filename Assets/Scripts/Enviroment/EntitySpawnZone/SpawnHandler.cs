using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

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
            SpawnZone zone = new SpawnZone(spawnArea.transform.position,
                                           spawnArea.Width, 
                                           spawnArea.Height * -1, 
                                           spawnArea.SpawnCount);
            zone.SpawnEntities();
            _spawnZones.Add(zone);
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
