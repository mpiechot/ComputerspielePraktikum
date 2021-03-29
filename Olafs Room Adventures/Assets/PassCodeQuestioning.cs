using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassCodeQuestioning : MonoBehaviour
{
	private bool triggered = false;
    private bool solved = false;

    [SerializeField]
	private Image Keypad;

    [SerializeField]
    private bool codeNR;

    [SerializeField]
    private Text Hint,enteredCode;

    private string Code2 = "6597";
    private string Code1 = "1234";
    private string Code;

    [SerializeField]
	private GameObject toDisableObject1,toDisableObject2;
    private string temp = "";

    // Start is called before the first frame update
    void Start()
    {
        enteredCode.color = Color.black;
        enteredCode.text = "";
        if (codeNR)
        {
            Code = Code2;
        }
        else {
            Code = Code1;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
    	if((collision.tag == "Player") && !solved)
    	{
            Debug.Log("triggerevent startet");
            triggered = true;
    		Hint.enabled = true;
    	}
    }

    private void OnTriggerExit(Collider collision)
    {
    	if((collision.tag == "Player") && !solved)
    	{
            Debug.Log("triggerevent endet");
            triggered = false;
    		Hint.enabled = false;
            Keypad.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
        	if(Input.GetKeyDown(KeyCode.L))
        	{
        		Hint.enabled = !Hint.enabled;
                Keypad.gameObject.SetActive(!Keypad.IsActive());
            }
        }
    }

    public void Enter0()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "0";
    	}
    }
    public void Enter1()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "1";
    	}
    }
    public void Enter2()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "2";
    	}
    }
    public void Enter3()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "3";
    	}
    }
    public void Enter4()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "4";
    	}
    }
    public void Enter5()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "5";
    	}
    }
    public void Enter6()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "6";
    	}
    }
    public void Enter7()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "7";
    	}
    }
    public void Enter8()
    {
    	if(Code.Length != enteredCode.text.Length)
    	{
    		enteredCode.text += "8";
    	}
    }
    public void Enter9()
    {
        if (Code.Length != enteredCode.text.Length)
        {
            enteredCode.text += "9";
        }
    }
    public void ReturnBtn()
    {
    	if(enteredCode.text.Length > 0)
    	{
    		enteredCode.text = enteredCode.text.Substring(0, (enteredCode.text.Length-1));
    	}
    }
    public void CheckBtn()
    {
        StartCoroutine(EnterCheck());
    }

    IEnumerator EnterCheck()
    {
        if (Code.Length != enteredCode.text.Length)
        {
            temp = enteredCode.text;
            enteredCode.text = "Entered Code is to short!";
            yield return new WaitForSeconds(3);
            enteredCode.text = temp;
        }

        if (Code.Length == enteredCode.text.Length)
        {
            if (Code == enteredCode.text)
            {
                toDisableObject1.SetActive(false);
                toDisableObject2.SetActive(false);
                enteredCode.text = "Correct";
                yield return new WaitForSeconds(3);
                Keypad.gameObject.SetActive(false);
                solved = true;
                triggered = false;

            }
            else
            {
                enteredCode.text = "Entered Code is wrong!";
                yield return new WaitForSeconds(3);
                enteredCode.text = "";
            }
        }
    }
}
