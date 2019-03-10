using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesController : MonoBehaviour
{
    public int EnemiesCount { get; private set; }

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _enemiesOnStart = 50;
    [SerializeField]
    private float _battleFieldRadius = 100;
    private List<GameObject> _enemies = new List<GameObject>();

    void Start()
    {
        CreateEnemies();
    }

    private void CreateEnemies()
    {
        float startPosition = _battleFieldRadius /2;
        int sqrt = Mathf.RoundToInt(Mathf.Sqrt(_enemiesOnStart));
        Vector3 enemyPosition = new Vector3(startPosition, startPosition, 0);
        for (int i = 0; i < sqrt; i++)
        {
            for (int j = 0; j < sqrt; j++)
            {
                CreateEnemy(enemyPosition, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
                enemyPosition.x -= _battleFieldRadius / sqrt;
            }
            enemyPosition.x = startPosition;
            enemyPosition.y -= _battleFieldRadius / sqrt;
        }
    }

    private void CreateEnemy(Vector3 position, Quaternion rotation)
    {
        Instantiate(_enemyPrefab, position, rotation, transform);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        _enemies.Remove(enemy);
        EnemiesCount--;
    }
}
