using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBarUIController : MonoBehaviour
{
    public Axis axis;
    public Slider positiveSlider;
    public Slider negativeSlider;
    public Color valueColor;

    public float maxValue;

    // Start is called before the first frame update
    void Start()
    {
        ColorBlock colors = positiveSlider.colors;
        colors.normalColor = valueColor;
        positiveSlider.colors = colors;
        negativeSlider.colors = colors;

        positiveSlider.maxValue = maxValue;
        negativeSlider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float gravity = 0f;
        switch (axis)
        {
            case Axis.X: gravity = Physics.gravity.x; break;
            case Axis.Y: gravity = Physics.gravity.y; break;
            case Axis.Z: gravity = Physics.gravity.z; break;
        }
        if (gravity > 0)
        {
            negativeSlider.value = 0;
            positiveSlider.value = gravity;
        }
        else
        {
            negativeSlider.value = Mathf.Abs(gravity);
            positiveSlider.value = 0;
        }
    }
}
