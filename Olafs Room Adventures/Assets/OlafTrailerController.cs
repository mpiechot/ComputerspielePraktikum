using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlafTrailerController : MonoBehaviour
{

    public List<GameObject> olafs;

    public void SetVisible()
    {
        foreach(GameObject go in olafs)
        {
            go.SetActive(true);
        }
    }
}
