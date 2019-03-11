using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton

    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameController");
                _instance = obj.AddComponent<GameController>();
                Debug.Log("Could not locate an GameController object. GameController was generated Automatically.");
            }
            return _instance;
        }
    }

    static GameController() { }

    #endregion

    private GameObject _player;

    private void Awake()
    {
        Events.LevelStarted += CreatePlayer;
    }

    private void OnDestroy()
    {
        Events.LevelStarted -= CreatePlayer;
    }

    private void CreatePlayer()
    {
        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.RestartPlayer();
        }
        else
        {
            if (_player == null)
            {
                _player = Resources.Load<GameObject>("Player");
            }
            Instantiate(_player);
        }
    }
}
