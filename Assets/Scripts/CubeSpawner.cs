using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _prefab;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(_prefab);
        }
    }
}
