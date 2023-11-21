using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private Vector3 _startSpawnPoint;
    [SerializeField] private Vector3 _endSpawnPoint;

    private void Update()
    {
        transform.position = Vector3.Lerp(_startSpawnPoint, _endSpawnPoint,Random.Range(0, 1));
    }
}
