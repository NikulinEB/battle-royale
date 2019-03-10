using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlComponent : MonoBehaviour
{
    [SerializeField]
    private float _rotationMultiplier = 1;

    void Start()
    {
        Events.Swipe += RotateShip;
    }

    private void OnDestroy()
    {
        Events.Swipe -= RotateShip;
    }

    private void RotateShip(float rotation)
    {
        transform.Rotate(0, 0, rotation * _rotationMultiplier, Space.Self);
    }
}
