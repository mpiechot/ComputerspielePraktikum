using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextRoomFade : MonoBehaviour
{
    public Image blackScreen;
    public int steps = 10;

    bool startFadeOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("FadeToNextRoom");
        }
    }

    private IEnumerator FadeToNextRoom()
    {
        while(blackScreen == null)
        {
            yield return 0;
        }
        for(int i=0;i < steps; i++)
        {
            blackScreen.color = new Color(0,0,0,Mathf.Lerp(0, 1, 1.0f / steps));
            yield return 0;
        }

        SceneManager.LoadScene(0);

        yield return 0;
    }
}
