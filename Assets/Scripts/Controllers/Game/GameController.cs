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
}
