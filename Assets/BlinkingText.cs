using TMPro;
using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
            if (textMeshPro == null)
            {
                textMeshPro = GetComponent<TextMeshProUGUI>();
            }
            StartCoroutine(Blink());

    }
    

    private IEnumerator Blink()
    {
        while (true)
        {
            textMeshPro.enabled = !textMeshPro.enabled;
            yield return new WaitForSeconds(1.25f);
        }
    }
}
