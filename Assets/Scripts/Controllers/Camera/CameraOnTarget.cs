using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnTarget : MonoBehaviour {

    public Transform target;
    private Vector3 offset;
    private Vector3 startPosition;

	private void Start ()
    {
        if (target)
        {
            offset = target.position - transform.position;
        }
        startPosition = transform.position;
        Events.LevelStarted += SetPlayerTarget;
    }

    private void OnDestroy()
    {
        Events.LevelStarted -= SetPlayerTarget;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(target.position.x - offset.x, target.position.y - offset.y, startPosition.z);
        }
        else
        {
            SetRandomTarget();
        }
    }

    private void SetPlayerTarget()
    {
        target = PlayerController.Instance.transform;
    }

    private void SetRandomTarget()
    {
        target = FindObjectOfType<EnemyAI>()?.transform;
    }
}
