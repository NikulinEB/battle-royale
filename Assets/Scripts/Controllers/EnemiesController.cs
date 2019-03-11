using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesController : MonoBehaviour
{

    #region Singleton

    private static EnemiesController _instance;

    public static EnemiesController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemiesController>();
            }
            if (_instance == null)
            {
                GameObject obj = new GameObject("EnemiesController");
                _instance = obj.AddComponent<EnemiesController>();
                Debug.Log("Could not locate an EnemiesController object. EnemiesController was generated Automatically.");
            }
            return _instance;
        }
    }

    static EnemiesController() { }

    #endregion

    public int EnemiesCount { get { return _enemies.Count; } }

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _enemiesOnStart = 50;
    [SerializeField]
    private float _battleFieldRadius = 100;
    private List<GameObject> _enemies = new List<GameObject>();

    void Start()
    {
        Events.LevelStarted += RemoveAllEnemies;
        Events.LevelStarted += CreateEnemies;
    }

    private void OnDestroy()
    {
        Events.LevelStarted -= RemoveAllEnemies;
        Events.LevelStarted -= CreateEnemies;
    }

    private void RemoveAllEnemies()
    {
        foreach(var enemy in _enemies)
        {
            enemy.SetActive(false);
            Destroy(enemy);
        }
        _enemies.Clear();
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
        _enemies.Add(Instantiate(_enemyPrefab, position, rotation, transform));
    }

    public void RemoveEnemy(GameObject enemy)
    {
        _enemies.Remove(enemy);
        CheckGameEnd();
    }

    private void CheckGameEnd()
    {
        if (EnemiesCount == 0 && PlayerController.Instance?.Lives > 0)
        {
            Events.ShowMenu_Call(MenuType.Win);
        }
    }
}
