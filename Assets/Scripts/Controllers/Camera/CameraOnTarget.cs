using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnTarget : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 1;
    private Vector3 offset;
    private bool shouldMove;
    private Vector3 startPosition;
    private Coroutine _moving;

	void Start () {

        //shouldMove = true;
        if (target)
        {
            offset = target.position - transform.position;
        }
        startPosition = transform.position;
        //Events.LevelLoaded += ToStartPosition;
        //Events.LevelLoaded += StartMoving;
        //Events.Death += StopMoving;
    }

    private void OnDestroy()
    {
        //Events.LevelLoaded -= ToStartPosition;
        //Events.LevelLoaded -= StartMoving;
        //Events.Death -= StopMoving;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(target.position.x - offset.x, target.position.y - offset.y, startPosition.z);
        }
        //if (shouldMove)
        //{
        //    if (TargetReached())
        //    {
        //        StopMoving();
        //    }
        //    MoveToTarget();
        //}
    }

    private void StartMoving()
    {
        shouldMove = true;
    }

    private void StopMoving(bool showAnimation)
    {
        StopMoving();
    }

    private void StopMoving()
    {
        shouldMove = false;
    }

    private void MoveToTarget()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x - offset.x, target.position.y - offset.y, startPosition.z), Time.deltaTime * moveSpeed);
        if (_moving == null)
        {
            _moving = StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
    {
        //var currentOffset = transform.position.y - HeroController.Instance.NewPosition.y;
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x - offset.x, target.position.y - offset.y, startPosition.z), Time.deltaTime * moveSpeed);
            yield return new WaitForEndOfFrame();
            //currentOffset = transform.position.y - HeroController.Instance.NewPosition.y;
        }
        _moving = null;
    }
        
    private bool TargetReached()
    {
        return transform.position.y - target.position.y - Mathf.Abs(offset.y) < 0.01f;
    }

    private void ToStartPosition()
    {
        transform.position = startPosition;
    }

}
