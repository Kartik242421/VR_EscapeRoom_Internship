using UnityEngine;
using UnityEngine.UI;

public class HeartRate : MonoBehaviour
{
    private RawImage rawImage;
    public float speed = 0.5f;
    private float uvReactX = 1.0f;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        uvReactX += speed * Time.deltaTime;

        if (uvReactX >= 10.0f)
        {
            uvReactX = 0f;
        }

        Rect uvRect = rawImage.uvRect;
        uvRect.x = uvReactX;
        rawImage.uvRect = uvRect;
    }
}
