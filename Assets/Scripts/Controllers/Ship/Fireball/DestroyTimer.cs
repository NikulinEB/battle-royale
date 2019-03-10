using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Delay for destroy after appearing.")]
    private float _delay = 3;

    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(this);
    }
}
