using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textspeed;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLines());

    }
    IEnumerator TypeLines()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
   /* void NextLine()
    {
        if (index < lines.Length-1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLines());   
        }
        else{
            gameObject.SetActive(false);
        }
    }*/
}
