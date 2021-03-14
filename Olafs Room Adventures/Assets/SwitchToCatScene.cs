using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToCatScene : MonoBehaviour
{
    private bool triggered = false;
    private AudioSource SoundSource;
    public AudioClip ReverseSound;
    private GameManager gameManager;
    private ReneStartSong song;
    // Start is called before the first frame update
    void Start()
    {
        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = ReverseSound;
        SoundSource.playOnAwake = false;

        gameManager = FindObjectOfType<GameManager>();
        song = FindObjectOfType<ReneStartSong>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            SoundSource.Play();
            song.FadeOut();
            StartCoroutine("goToCatRoom");
        }
    }

    IEnumerator goToCatRoom()
    {
        yield return new WaitForSeconds(2);
        gameManager.FadeOut();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("CatRoom");
    }
}
