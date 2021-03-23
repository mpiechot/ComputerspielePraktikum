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

    private bool CR_Running = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Material.mainTexture = textures[0];
        PlayAnimation();
    }

    // Update is called once per frame
    public void PlayAnimation()
    {
        if (!CR_Running)
        {
            StartCoroutine(SwitchtexturesInOrder());
        }
    }

    private IEnumerator SwitchtexturesInOrder()
    {
        CR_Running = true;
        for (int i = 0; i < textures.Length; i++)
        {
            m_Material.mainTexture = textures[i];
            yield return new WaitForSeconds(animationDelay);
        }
        CR_Running = false;
    }

    private void OnDestroy()
    {
        m_Material.mainTexture = textures[0];
    }
}
