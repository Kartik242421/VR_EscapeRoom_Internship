using UnityEngine;

public class RaycastDebugTool : MonoBehaviour
{
    // Start point of the ray
    public Transform startPoint;

    // End point of the ray
    public Transform endPoint;

    void Update()
    {
        if (startPoint != null && endPoint != null)
        {
            // Calculate the direction from the start point to the end point
            Vector3 direction = endPoint.position - startPoint.position;
            float distance = direction.magnitude; // Calculate the distance between the two points
            direction.Normalize(); // Normalize the direction vector

            // RaycastHit will store information about what was hit by the ray
            RaycastHit hit;

            // Cast the ray from start point in the direction calculated above
            if (Physics.Raycast(startPoint.position, direction, out hit, distance))
            {
                // Debug log the name of the object that was hit
                Debug.Log("Raycast from " + startPoint.position + " to " + endPoint.position);
                Debug.Log("Direction: " + direction);
                Debug.Log("Hit: " + hit.collider.name + " at distance: " + hit.distance);

                // Optionally, draw the ray in the Scene view for visual debugging
                Debug.DrawRay(startPoint.position, direction * hit.distance, Color.red);
            }
            else
            {
                // If nothing was hit, log the attempt and draw the ray for visual debugging
                Debug.Log("Raycast from " + startPoint.position + " to " + endPoint.position);
                Debug.Log("Direction: " + direction);
                Debug.Log("No hit detected");
                Debug.DrawRay(startPoint.position, direction * distance, Color.green);
            }
        }
        else
        {
            Debug.LogWarning("StartPoint or EndPoint is not assigned.");
        }
    }
}
