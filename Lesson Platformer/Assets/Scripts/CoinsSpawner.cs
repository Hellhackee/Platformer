using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _pool;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            GameObject coin = Instantiate(_template, _pool);
            coin.transform.position = _spawnPoints[i].position;
        }
    }
}
