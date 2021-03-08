using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePillar : MonoBehaviour
{
    [SerializeField]
    private static float stepSize = 0.01f;
    [SerializeField]
    private float yEndPosition;
    private float yStartPosition;
    private bool stateStart = true;

    // Start is called before the first frame update
    void Start()
    {
        yStartPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float targetY = stateStart ? yStartPosition : yEndPosition;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetY, stepSize), transform.position.z);      
    }
    public void ChangeState()
    {
        stateStart = !stateStart;
    }
}
