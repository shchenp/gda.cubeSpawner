using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private float _spawnBreakTime;
    [SerializeField] private Vector3 _startSpawnPoint;
    [SerializeField] private Vector3 _endSpawnPoint;

    private float _lastSpawnTime;

    private void Update()
    {
        // _lastSpawnTime += Time.deltaTime;
        //&& _lastSpawnTime >= _spawnBreakTime
        if (Input.GetKey(KeyCode.Space))
        {
            var cube = Instantiate(_prefab, transform);
            cube.position = Vector3.Lerp(_startSpawnPoint, _endSpawnPoint, Random.Range(0f, 1f));
            //_lastSpawnTime = 0;
        }
    }
}
