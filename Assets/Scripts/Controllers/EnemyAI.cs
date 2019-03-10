using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _visibleDistance = 1;
    [SerializeField]
    [Tooltip("Rotation angle per fixed update.")]
    private float _rotationAngle;
    [SerializeField]
    private Transform _raycastStartPosition;
    private Transform _goal;
    private Coroutine _searching;

    void Awake()
    {
        _searching = StartCoroutine(GoalSearching());
    }

    private void OnDestroy()
    {
        StopCoroutine(_searching);
    }

    private IEnumerator GoalSearching()
    {
        RaycastHit2D raycastHit;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            raycastHit = Physics2D.Raycast(_raycastStartPosition.position, transform.TransformDirection(0, 1, 0), distance : _visibleDistance, layerMask : LayerMask.GetMask("Ships"));
            //Debug.Log("raycastHit " + raycastHit.collider?.name);
            if (raycastHit.transform == null)
            {
                Rotate();
            }
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, _rotationAngle, Space.Self);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(0, 1 * _visibleDistance, 0));
    }
}
