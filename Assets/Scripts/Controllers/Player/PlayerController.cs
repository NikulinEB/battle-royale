using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }
            if (_instance == null)
            {
                GameObject obj = new GameObject("PlayerController");
                _instance = obj.AddComponent<PlayerController>();
                Debug.Log("Could not locate an PlayerController object. PlayerController was generated Automatically.");
            }
            return _instance;
        }
    }

    static PlayerController() { }

    #endregion

    private void OnDestroy()
    {
        Events.ShowMenu_Call(MenuType.Defeat);
    }

}
