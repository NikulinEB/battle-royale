using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    private LivesComponent _playerLives;
    private Text _counter;

    void Start()
    {
        _playerLives = FindObjectOfType<PlayerController>()?.GetComponent<LivesComponent>();
        _counter = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        _counter.text = "Lives: " + _playerLives.Lives.ToString();
    }

}
