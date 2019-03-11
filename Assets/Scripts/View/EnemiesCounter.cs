using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemiesCounter : MonoBehaviour
{
    private Text _counter;

    void Start()
    {
        _counter = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        _counter.text = "Enemies: " + EnemiesController.Instance.EnemiesCount.ToString();
    }
}
