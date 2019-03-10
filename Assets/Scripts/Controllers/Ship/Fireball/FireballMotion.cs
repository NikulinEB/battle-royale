using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMotion : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
        
    }

    void  FixedUpdate()
    {
        transform.Translate(0, -1 * _speed, 0, Space.Self);
    }
}
