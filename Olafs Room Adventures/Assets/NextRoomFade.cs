using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextRoomFade : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("NextScene");
        }
    }
    IEnumerator NextScene()
    {
        gm.FadeOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
