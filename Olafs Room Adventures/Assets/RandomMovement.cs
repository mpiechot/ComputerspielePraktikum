using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f;

    [SerializeField]
    private int changeDirectionSeconds = 3;
    [SerializeField]
    private BoxCollider limits;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 startPos;

    private bool outside = false;

    private void Start()
    {
        startPos = limits.center;
        StartCoroutine("ChangeDirection");
    }
    // Update is called once per frame
    void Update()
    {
        if (!outside)
        {
            if (!InRange())
            {
                Debug.Log("Out of range!!");
                moveVector = (startPos - transform.position).normalized * speed * Time.deltaTime;
                outside = true;
                StopCoroutine("ChangeDirection");
            }
        }
        else
        {
            if (Vector3.Distance(transform.position,startPos) < 2)
            {
                outside = false;
                StartCoroutine("ChangeDirection");
            }
        }
        transform.position += moveVector;
    }
    IEnumerator ChangeDirection()
    {
        while (true)
        {
            float xValue = ((Random.value * 2) - 1);

            float yValue = ((Random.value * 2) - 1);
            float zValue = ((Random.value * 2) - 1);
 
            moveVector = new Vector3(xValue, yValue, zValue).normalized * speed * Time.deltaTime;

            transform.LookAt(transform.position + moveVector);
            yield return new WaitForSeconds(changeDirectionSeconds);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + moveVector*speed*3);
    }

    private bool InRange()
    {
        return limits.bounds.Contains(transform.position);
        //return InRange(transform.position.x, limits.bounds.center+Vector3.left*limits.bounds.extents.x + Vector3.up*limits.bounds.extents.x) 
        //    && InRange(transform.position.y, yLimits) 
        //    && InRange(transform.position.z, zLimits);
    }
    private bool InRange(float value, Vector2 limit)
    {
        return value >= limit.x && value <= limit.y;
    }
}
