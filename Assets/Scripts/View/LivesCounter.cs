using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    private LivesComponent _playerLives;
    private Text _counter;

    void Start()
    {
        _counter = GetComponent<Text>();
        Events.LevelStarted += SetLivesComponent;
    }

    private void OnDestroy()
    {
        Events.LevelStarted -= SetLivesComponent;
    }

    private void SetLivesComponent()
    {
        _playerLives = PlayerController.Instance.GetComponent<LivesComponent>();

    }

    private void FixedUpdate()
    {
        _counter.text = "Lives: " + _playerLives?.Lives.ToString();
    }

}
