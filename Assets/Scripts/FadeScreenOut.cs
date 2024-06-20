using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FadeScreenOut : MonoBehaviour
{
    public bool fadeOnStart;
    public bool fadeOnEnd;
    public float fadeDuration = 2;
    public Color fadeColor;
    public Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled=false;
        if(fadeOnStart){
            FadeIn();
        }
        if(fadeOnEnd){
            FadeOut();
        }
    }

    public void FadeIn(){
        Fade(1,0);
    }
    public void FadeOut(){
        Fade(0,1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));

    }
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        //rend.enabled=true;
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration); 

            rend.material.SetColor("_Color",newColor); 

            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        
        rend.material.SetColor("_Color",newColor2); 

    }
}
