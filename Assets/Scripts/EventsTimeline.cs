using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EventsTimeline : MonoBehaviour
{
    PlayableDirector dir;
    public List<step> steps;
    // Start is called before the first frame update
    void Start()
    {
        dir = GetComponent<PlayableDirector>();

    }
    [System.Serializable]
    public class step
    {
        public string name;
        public float time;
        public bool hasPlayed  = false;

    }
    public void PlayStepIndex(int index)
    {
        step Step = steps[index];
        if (!Step .hasPlayed)
        {
            Step.hasPlayed = true;
            dir.Stop();
            dir.time = Step.time;
            dir.Play();
        }

    }

 
}
