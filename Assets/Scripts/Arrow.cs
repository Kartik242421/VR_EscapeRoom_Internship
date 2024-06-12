using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;
    public float arrowSpeed = 10f; // Optional speed if you plan to move the arrow in the future
    public Vector3 rotationOffset = new Vector3(0, 88, 0); // Adjust this if the offset is around a different axis

    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Calculate the direction towards the target
        Vector3 direction = target.position - transform.position;

        // Rotate the arrow to face the target
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Apply the rotation offset
        Quaternion adjustedRotation = lookRotation * Quaternion.Euler(rotationOffset);

        transform.rotation = adjustedRotation;
    }
}
