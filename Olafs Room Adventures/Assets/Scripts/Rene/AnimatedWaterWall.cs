using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedWaterWall : MonoBehaviour
{
    [SerializeField]
    private float speedX = 0.0f;
    [SerializeField]
    private float speedY = 1.5f;

    private float curX;
    private float curY;
    // Start is called before the first frame update
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(curX, curY));
    }
}
