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
            return _instance;
        }
    }

    static PlayerController() { }

    #endregion

    public int Lives { get { return _livesComponent.Lives; } }
    private LivesComponent _livesComponent;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _livesComponent = GetComponent<LivesComponent>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void OnDestroy()
    {
        Events.ShowMenu_Call(MenuType.Defeat);
    }

    public void RestartPlayer()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _livesComponent.ResetLives();
    }

}
