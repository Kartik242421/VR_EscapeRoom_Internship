using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PuzzleManager : MonoBehaviour
{
    public int sizeRow, sizeCol;
    int countPoint = 0;
    int countImageKey = 0;
    public List<GameObject> imageKeyList; // run from 0 ---> list.count
    public List<GameObject> imageOfPictureList;
    public List<GameObject> checkPointList;
    GameObject[,] imageKeyMatrix;
    GameObject[,] imageOfPictureMatrix;
    GameObject[,] checkPointMatrix;

    // Use this for initialization
    void Start()
    {
        checkPointManager();
        ImageKeyManager();


    }
    void checkPointManager()
    {
        for (int r = 0; r < sizeRow; r++)
        {//run rov
            for (int c = 0; c < sizeCol; c++)
            {//run col
                checkPointMatrix[r, c] = checkPointList[countPoint];
                countPoint++;

            }
        }

    }
    void ImageKeyManager()
    {

        for (int r = 0; r < sizeRow; r++)
        {//run rov
            for (int c = 0; c < sizeCol; c++)
            {

                imageKeyMatrix[r, c] = imageKeyList[countImageKey];
                countImageKey++;
            }
        }
    }
    void ImagePlacement()
    {
        imageOfPictureMatrix[0, 0] = imageOfPictureList[2];
        imageOfPictureMatrix[0, 1] = imageOfPictureList[1];
        imageOfPictureMatrix[0, 2] = imageOfPictureList[0];
        imageOfPictureMatrix[1, 0] = imageOfPictureList[5];
        imageOfPictureMatrix[1, 1] = imageOfPictureList[4];
        imageOfPictureMatrix[1, 2] = imageOfPictureList[3];
        imageOfPictureMatrix[2, 0] = imageOfPictureList[8];
        imageOfPictureMatrix[2, 1] = imageOfPictureList[7];
        imageOfPictureMatrix[2, 2] = imageOfPictureList[6];
    }
}