using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimator : MonoBehaviour
{
    [SerializeField]
    private Material m_Material;
    [SerializeField]
    private Texture[] textures;
    private float animationDelay = 0.1f;

    [SerializeField] 
    private bool SwitchAtRandom = false;
    [SerializeField]
    private bool PlayOnAwake = false;
    [SerializeField]
    private bool PlayOnRepeat = false;
    private float randomRange = 3f;

    private bool CR_Running = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Material.mainTexture = textures[0];
        if (PlayOnAwake)
        {
            if (SwitchAtRandom)
            {
                StartCoroutine(SwitchtexturesRandom());
            }
            else 
            {
                StartCoroutine(SwitchtexturesInOrder());
            }

            
        }
    }

    private void Update()
    {
        if(PlayOnRepeat)
            PlayAnimation();
    }
    // Update is called once per frame
    public void PlayAnimation()
    {
        if (!CR_Running)
        {
            if (SwitchAtRandom)
            {
                StartCoroutine(SwitchtexturesRandom());
            }
            else
            {
                StartCoroutine(SwitchtexturesInOrder());
            }
        }
    }

    private IEnumerator SwitchtexturesInOrder()
    {
        CR_Running = true;
        for (int i = 0; i < textures.Length; i++)
        {
            m_Material.mainTexture = textures[i];
            if (SwitchAtRandom)
                animationDelay = Random.Range(3, randomRange);
            yield return new WaitForSeconds(animationDelay);
        }
        CR_Running = false;
    }

    private IEnumerator SwitchtexturesRandom()
    {
        CR_Running = true;

        animationDelay = Random.Range(8, randomRange);
        yield return new WaitForSeconds(animationDelay);
        
        int i = Random.Range(0, textures.Length);
        m_Material.mainTexture = textures[i];
        
        CR_Running = false;
    }



    private void OnDestroy()
    {
        m_Material.mainTexture = textures[0];
    }
}
