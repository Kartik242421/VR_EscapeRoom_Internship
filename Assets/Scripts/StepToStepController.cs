using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StepToStepController : MonoBehaviour
{
    public InputActionProperty trig;
    public float trigger;
    public int row, col;
    private PuzzleManager gameMN;
    public Transform handTransform; // Add this line for the hand model

    // Start is called before the first frame update
    void Start()
    {
        GameObject gamemanager = GameObject.Find("PuzzleManager");
        gameMN = gamemanager.GetComponent<PuzzleManager>();

        // Ensure the GameObject has a Collider component
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        // Ensure the handTransform is assigned
        if (handTransform == null)
        {
            Debug.LogError("Hand transform is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        trigger = trig.action.ReadValue<float>();
        Debug.Log(trigger);
        DetectClick();
    }

    void DetectClick()
    {
        if (trigger >= 1f) // 0 is the left mouse button
        {
            if (handTransform == null) return;

            // Use the hand transform's position and forward direction to create the ray
            Ray ray = new Ray(handTransform.position, handTransform.forward);
            RaycastHit hit;

            // Draw the ray in the Scene view for debugging
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2.0f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnClick();
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }
        }
    }

    void OnClick()
    {
        Debug.Log("Row is :" + row + " column is :" + col);
        gameMN.countStep += 1;
        gameMN.row = row;
        gameMN.col = col;
        gameMN.startControl = true;
    }
}
