
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnZone
{
    private int _maxSpawns;
    private int _spawnCount = 0;
    
    private Vector2 _position;
    private Vector2 _size;
    private List<GameObject> _entityPrefabs;
    
    // Start is called before the first frame update
    
    public SpawnZone(Vector2 position, float width, float height, int maxSpawns)
    {
        _position = position;
        _size = new Vector2(width, height);
        _maxSpawns = maxSpawns;

        _entityPrefabs = new List<GameObject>();
        if (_entityPrefabs.Count == 0)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Entities/Enemy");
            _entityPrefabs.Add(prefab);
        }
        if (_entityPrefabs.Count == 0)
        {
            Debug.LogError("Failed to load enemy prefab.");
            return;
        }


    }
       
    public Vector2 GetRandomPosInSpawnBounds()
    {
        return new Vector2(
            Random.Range(_position.x, _position.x + _size.x),
            Random.Range(_position.y, _position.y + _size.y)
            );
    }

    public void SpawnEntities()
    {
       
        if (_entityPrefabs.Count > 0 ) 
        {
            for (; _spawnCount < _maxSpawns; _spawnCount++)
            {
                Vector2 rdmSpawnPoint = GetRandomPosInSpawnBounds();
                GameObject newEnemy = GameObject.Instantiate(_entityPrefabs[0], rdmSpawnPoint, Quaternion.identity);
                newEnemy.GetComponent<EnemyBehaviour>().SpawnPosition = rdmSpawnPoint;
            }
        }

    }
}
