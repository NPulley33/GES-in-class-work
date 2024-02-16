using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCode : MonoBehaviour
{

    [SerializeField]
    int[] scoresArr = new int[4];
    int[][] scoreArr = new int[4][];
    int[,] scoreArr2 = new int[3, 3];

    [ContextMenu("Array Test")]
    void Execute() {

        scoreArr[0] = new int[4] { 1, 2, 3, 4 };
        scoreArr[1] = new int[4] { 5, 6, 7, 8 };
        scoreArr[2] = new int[4] { 9, 10, 11, 12 };
        scoreArr[3] = new int[4] { 13, 14, 15, 16 };

        //for (int i = 0; i < scoresArr.Length; i++) {
        //    Debug.LogFormat("{0}", scoresArr[i]);
        //}

        for (int i = 0; i < scoreArr.Length; i++) {
            for (int j = 0; j < scoreArr[i].Length; j++) {
                Debug.Log(scoreArr[i][j]);
            }
        }

        int numberOfRows = scoreArr2.GetLength(0);
        int numberOfCols = scoreArr2.GetLength(1);
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfCols; j++)
            {
                Debug.Log(scoreArr2[i,j]);
            }
        }

    }

}
