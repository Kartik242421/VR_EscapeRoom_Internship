using UnityEngine;
using System.Collections;
public class ImageController : MonoBehaviour
{
    public GameObject target;
    public bool startMove = false;
    PuzzleManager gameMN;
    // Use this for initialization
    void Start()
    {
        GameObject gamemanager = GameObject.Find("PuzzleManager");
        gameMN = gamemanager.GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            startMove = false;
            this.transform.position = target.transform.position;//m
            gameMN.checkComplete = true;
        }
    }
}