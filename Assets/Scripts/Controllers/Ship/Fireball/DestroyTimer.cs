using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Delay for destroy after appearing (in seconds).")]
    private float _delay = 3;

    void Start()
    {
        Events.LevelStarted += DestroyBeforeStart;
        StartCoroutine(DestroyDelay());
    }

    private void OnDestroy()
    {
        Events.LevelStarted -= DestroyBeforeStart;
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }

    private void DestroyBeforeStart()
    {
        Destroy(gameObject);
    }
}
