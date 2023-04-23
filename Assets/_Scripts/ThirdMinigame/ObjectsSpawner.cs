using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private bool _spawnOnStart;
    [SerializeField] private float _timeToStartSpawn;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private GameObject _spawnPrefab;
    private float _maxXSpawnCoordinateX;
    private float _maxXSpawnCoordinateY;

    private void Awake()
    {
        var localScale = _spawnZone.localScale;
        _maxXSpawnCoordinateX = localScale.x / 2;
        _maxXSpawnCoordinateY = localScale.y / 2;
        
        if (_spawnOnStart)
            StartSpawn();
    }

    private void OnEnable()
    {
        StopSpawn();
        if (_spawnOnStart)
        {
            StopSpawn();
            StartSpawn();
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeToStartSpawn);
        while (true)
        {
            var position = _spawnZone.transform.position;
            var spawnX = position.x + Random.Range(-_maxXSpawnCoordinateX, _maxXSpawnCoordinateX);
            var spawnY = position.y + Random.Range(-_maxXSpawnCoordinateY, _maxXSpawnCoordinateY);
            var spawnPosition = new Vector2(spawnX, spawnY);
            
            Instantiate(_spawnPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }
}
