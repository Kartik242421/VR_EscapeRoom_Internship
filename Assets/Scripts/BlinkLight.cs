using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
    public GameObject targetObject; 
    public float blinkInterval = 0.5f; 

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = gameObject; 
        }

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            targetObject.SetActive(!targetObject.activeSelf); 
        }
    }
}
