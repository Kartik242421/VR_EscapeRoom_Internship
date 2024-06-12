using UnityEngine;
using System.Collections;

public class SlidingDoorWithDelay : MonoBehaviour
{
    public Transform door;
    public float openHeight = 3.0f;
    public float speed = 2.0f;
    public float delay = 3.0f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = door.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    void Update()
    {
        if (isOpening)
        {
            door.position = Vector3.Lerp(door.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
            StopAllCoroutines();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoorAfterDelay());
        }
    }
    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        isOpening = false;
    }
}
