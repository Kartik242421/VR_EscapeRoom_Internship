using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PuzzleManager : MonoBehaviour
{
    public int row, col, countStep;
    public int sizeRow, sizeCol;
    public int rowBlank, colBlank;
    int countPoint = 0;
    int countImageKey = 0;
    int countComplete = 0;
    public bool gameisComplete;
    public bool startControl = false;
    public bool checkComplete;
    GameObject temp;
    public List<GameObject> imageKeyList; // run from 0 ---> list.count
    public List<GameObject> imageOfPictureList;
    public List<GameObject> checkPointList;
    GameObject[,] imageKeyMatrix;
    GameObject[,] imageOfPictureMatrix;
    GameObject[,] checkPointMatrix;

    // Use this for initialization
    void Start()
    {
        imageKeyMatrix = new GameObject[sizeRow, sizeCol];
        imageOfPictureMatrix = new GameObject[sizeRow, sizeCol];
        checkPointMatrix = new GameObject[sizeRow, sizeCol];
        checkPointManager();
        ImageKeyManager();
        ImagePlacement();

        for (int r = 0; r < sizeRow; r++)
        { //run row
            for (int c = 0; c < sizeCol; c++)
            { //run col
                if (imageOfPictureMatrix[r, c].name.CompareTo("blank") == 0)
                {
                    rowBlank = r;
                    colBlank = c;
                    break;
                }
            }
        }


    }
    void Update()
    {
        if (startControl)
        {
            startControl = false;
            if (countStep == 1)
            {
                if (imageOfPictureMatrix[row, col] != null && imageOfPictureMatrix[row, col].name.CompareTo("blank") != 0)
                {
                    if (rowBlank != row && colBlank == col)
                    {
                        if (Mathf.Abs(row - rowBlank) == 1)
                        {
                            SortImage();
                            countStep = 0;

                        }
                        else
                        {

                            countStep = 0;//not move
                        }
                    }
                    else if (rowBlank == row && colBlank != col)
                    {
                        if (Mathf.Abs(col - colBlank) == 1)
                        {
                            SortImage();
                            countStep = 0;

                        }
                        else
                        {

                            countStep = 0;//not move
                        }
                    }
                    else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col))
                    {
                        countStep = 0;
                    }
                }
                else
                {

                    countStep = 0;//not move
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (checkComplete)
        {
            checkComplete = false;
            for (int r = 0; r < sizeRow; r++)
            { //run row
                for (int c = 0; c < sizeCol; c++)
                { //run colum
                    if (imageKeyMatrix[r, c].gameObject.name.CompareTo(imageOfPictureMatrix[r, c].gameObject.name) == 0)
                    {
                        countComplete++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (countComplete == checkPointList.Count)
            {
                gameisComplete = true;
                Debug.Log("Game Is Complete");
            }
            else
            {
                countComplete = 0;
            }
        }
    }
    void SortImage()
    {
        temp = imageOfPictureMatrix[rowBlank, colBlank];
        imageOfPictureMatrix[rowBlank, colBlank] = null;
        imageOfPictureMatrix[rowBlank, colBlank] = imageOfPictureMatrix[row, col];
        imageOfPictureMatrix[row, col] = null;
        imageOfPictureMatrix[row, col] = temp;
        imageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().target = checkPointMatrix[rowBlank, colBlank];
        imageOfPictureMatrix[row, col].GetComponent<ImageController>().target = checkPointMatrix[row, col];
        imageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().startMove = true;
        imageOfPictureMatrix[row, col].GetComponent<ImageController>().startMove = true;
        rowBlank = row;
        colBlank = col;

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
        imageOfPictureMatrix[0, 0] = imageOfPictureList[0];
        imageOfPictureMatrix[0, 1] = imageOfPictureList[2];
        imageOfPictureMatrix[0, 2] = imageOfPictureList[5];
        imageOfPictureMatrix[1, 0] = imageOfPictureList[4];
        imageOfPictureMatrix[1, 1] = imageOfPictureList[1];
        imageOfPictureMatrix[1, 2] = imageOfPictureList[7];
        imageOfPictureMatrix[2, 0] = imageOfPictureList[3];
        imageOfPictureMatrix[2, 1] = imageOfPictureList[6];
        imageOfPictureMatrix[2, 2] = imageOfPictureList[8];
    }
}