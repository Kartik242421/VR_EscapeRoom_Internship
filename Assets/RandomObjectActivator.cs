using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectActivator : MonoBehaviour
{
    public List<GameObject> objectsToActivate; // List of GameObjects to activate/deactivate
    public float activationDuration = 2.0f; // Duration in seconds for which each group of GameObjects will stay active

    private void Start()
    {
        StartCoroutine(ContinuousActivationRoutine());
    }

    private IEnumerator ContinuousActivationRoutine()
    {
        while (true)
        {
            // Determine how many objects to activate (between 1 and objectsToActivate.Count)
            int countToActivate = Random.Range(1, objectsToActivate.Count + 1);

            // Create a list to hold the objects to activate
            List<GameObject> objectsToActivateNow = new List<GameObject>();

            // Select 'countToActivate' random objects from objectsToActivate
            for (int i = 0; i < countToActivate; i++)
            {
                int randomIndex = Random.Range(0, objectsToActivate.Count);
                GameObject objectToActivate = objectsToActivate[randomIndex];
                objectsToActivateNow.Add(objectToActivate);
            }

            // Activate the selected objects
            foreach (GameObject obj in objectsToActivateNow)
            {
                obj.SetActive(true);
            }

            // Wait for activationDuration seconds
            yield return new WaitForSeconds(activationDuration);

            // Deactivate all the objects that were activated
            foreach (GameObject obj in objectsToActivateNow)
            {
                obj.SetActive(false);
            }
        }
    }
}
