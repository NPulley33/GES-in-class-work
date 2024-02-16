using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HanoiTower : MonoBehaviour
{
    [SerializeField] private Transform peg1Transform;
    [SerializeField] private Transform peg2Transform;
    [SerializeField] private Transform peg3Transform;

    [SerializeField] private int[] peg1Data = { 1, 2, 3, 4, 5 };
    [SerializeField] private int[] peg2Data = { 0, 0, 0, 0, 0 };
    [SerializeField] private int[] peg3Data = { 0, 0, 0, 0, 0 };
    [SerializeField] private int currentPeg = 1;

    [SerializeField] private GameObject winLabel;
    [SerializeField] private TextMeshProUGUI currentPegLabel;

    [ContextMenu("Move Right")]
    public void MoveRight()
    {
        int pegToMove;

        //Make sure we aren't the right most peg
        if (CanMoveRight() == false) pegToMove = -2;
        else pegToMove = 1;

        //Check to see what index and number we are moving from THIS peg
        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        //If there wasn't anything to move then don't try to move
        if (fromIndex == -1) return;

        //Check to see where in the peg we are moving to that the number
        //should be placed into
        int[] toArray = GetPeg(currentPeg + pegToMove);
        int toIndex = GetIndexOfFreeSlot(toArray);

        //If the adjacent peg is FULL then we cannot move anything into it
        //This probably will never happen since the max number of numbers
        //we have is the size of each peg
        if (toIndex == -1) return;

        //Lastly check to verify the number we are moving is not larger
        //than whatever number we may be placing this number on top of
        //on the adjacent peg
        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        //If all checks PASS then go aheand and move the number
        //out of THIS array into the adjacent array
        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg + pegToMove);
        disc.SetParent(toPeg);

        if (CheckWin())
        {
            winLabel.SetActive(true);
        }
    }

    [ContextMenu("Move Left")]
    public void MoveLeft()
    {
        int pegToMove;

        //Make sure we aren't the left most peg
        if (CanMoveLeft() == false) pegToMove= 2;
        else pegToMove = -1; 

        //Check to see what index and number we are moving from THIS peg
        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        //If there wasn't anything to move then don't try to move
        if (fromIndex == -1) return;

        //Check to see where in the peg we are moving to that the number
        //should be placed into
        int[] toArray = GetPeg(currentPeg + pegToMove);
        int toIndex = GetIndexOfFreeSlot(toArray);

        //If the adjacent peg is FULL then we cannot move anything into it
        //This probably will never happen since the max number of numbers
        //we have is the size of each peg
        if (toIndex == -1) return;

        //Lastly check to verify the number we are moving is not larger
        //than whatever number we may be placing this number on top of
        //on the adjacent peg
        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        //If all checks PASS then go aheand and move the number
        //out of THIS array into the adjacent array
        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg + pegToMove);
        disc.SetParent(toPeg);

        if (CheckWin()) {
            winLabel.SetActive(true);
        }
    }

    public void IncrementPegNumber() {
        currentPeg++;
        if (currentPeg > 3) currentPeg = 3;
        UpdateCurrentPegLabel();
    }
    public void DecrementPegNumber() {
        currentPeg--;
        if (currentPeg < 1) currentPeg = 1;
        UpdateCurrentPegLabel();
    }

    void UpdateCurrentPegLabel() {
        currentPegLabel.text = $"Selected Peg: Peg {currentPeg}";
    }
    bool CheckWin() {
        //something about this is wrong- finds win too soon with 5 pegs
        for (int i = peg3Data.Length - 1; i > - 1; i--) {
            if (peg3Data[i] == 0) return false;
        }
        return true;
    }

    Transform PopDiscFromCurrentPeg() {
        Transform currentPegTransform = GetPegTransform(currentPeg);
        int index = currentPegTransform.childCount -1;
        Transform disc = currentPegTransform.GetChild(index);
        return disc;
    }
    Transform GetPegTransform(int pegNumber) {
        return GameObject.Find($"Peg{pegNumber}").transform;
        //Button buttons[] = GameObject.FindObjectByType<Button>(FindObjectSortMode.None);
    }

    void MoveNumber(int[] fromArr, int fromIndex, int[] toArr, int toIndex)
    {
        int value = fromArr[fromIndex];
        fromArr[fromIndex] = 0;
        toArr[toIndex] = value;
    }
    bool CanMoveRight()
    {
        //If peg 1 or 2 then can move right
        return currentPeg < 3;
    }
    bool CanAddToPeg(int value, int[] peg)
    {
        int topNumberIndex = GetTopNumberIndex(peg);
        if (topNumberIndex == -1) return true;
        int topNumber = peg[topNumberIndex];
        return topNumber > value;
    }
    bool CanMoveLeft()
    {
        //If peg 2 or 3 then can move right
        return currentPeg > 1;
    }
    int[] GetPeg(int pegNumber)
    {
        if (pegNumber == 1) return peg1Data;
        if (pegNumber == 2) return peg2Data;
        return peg3Data;
    }
    int GetTopNumberIndex(int[] peg)
    {
        for (int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }
        return -1;
    }
    int GetIndexOfFreeSlot(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }
        return -1;
    }
}
