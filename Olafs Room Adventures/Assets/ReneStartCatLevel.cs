using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReneStartCatLevel : MonoBehaviour
{
    private AudioSource SoundSource;
    public AudioClip TrailerSound;
    private GameManager gameManager;
    [SerializeField]
    private Light light;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeIn();

        SoundSource = gameObject.AddComponent<AudioSource>();
        SoundSource.clip = TrailerSound;
        SoundSource.playOnAwake = false;

        SoundSource.Play();
        
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light.range = Mathf.Lerp(light.range, 60, Time.deltaTime);
    }
}
