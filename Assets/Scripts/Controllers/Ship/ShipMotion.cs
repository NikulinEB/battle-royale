using UnityEngine;
using System.Collections;

public class ShipMotion : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(0, -1 * _speed, 0, Space.Self);
    }
}
