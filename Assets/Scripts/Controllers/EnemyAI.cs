using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _visibleDistance = 1;
    [SerializeField]
    [Tooltip("Rotation angle per fixed update.")]
    private float _rotationAngle;
    private Transform _goal;
    private Coroutine _searching;

    void Awake()
    {
        _searching = StartCoroutine(GoalSearching());
    }

    private void OnDestroy()
    {
        StopCoroutine(_searching);
        EnemiesController.Instance.RemoveEnemy(gameObject);
    }

    private IEnumerator GoalSearching()
    {
        Vector3 shipForward;
        Vector3 toCenter;
        RaycastHit2D raycastHit = new RaycastHit2D();
        float rayDirection = -1;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            rayDirection = 0;
            while (rayDirection < 360 && raycastHit.transform == null)
            {
                raycastHit = Physics2D.Raycast(transform.position, transform.TransformDirection((float)Math.Cos(rayDirection), (float)Math.Sin(rayDirection), 0), distance: _visibleDistance, layerMask: LayerMask.GetMask("Ships"));
                //Debug.DrawRay(transform.position, transform.TransformDirection((float)Math.Cos(rayDirection), (float)Math.Sin(rayDirection), 0));
                rayDirection += 5f;
            }
            shipForward = transform.TransformDirection(0, Mathf.Sign(_visibleDistance) * 1, 0);
            toCenter = (Vector3.zero - transform.position).normalized;
            if (raycastHit.transform == null)
            {
                if ((Math.Round(shipForward.x, 1) != Math.Round(toCenter.x, 1)) || (Math.Round(shipForward.y, 1) != Math.Round(toCenter.y, 1)))
                {
                    Rotate(shipForward, toCenter);
                }
            }
            else
            {
                Rotate(shipForward, (raycastHit.transform.position - transform.position));
            }
        }
    }

    private void Rotate(Vector3 from, Vector3 to)
    {
        var vectorsAngle = Vector3.SignedAngle(from, to, new Vector3(0, 0, 1));
        var angle = _rotationAngle * Math.Sign(vectorsAngle);
        transform.Rotate(0, 0, angle, Space.Self);
    }


}
