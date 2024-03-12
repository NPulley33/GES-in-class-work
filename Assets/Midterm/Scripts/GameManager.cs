using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Flow { 
    public class GameManager : MonoBehaviour
    {
        //1 = red, 2 = green, 3 = blue, 4 = yellow, 5 = purple
        private int[,] grid =
            {  //top left 0,0
                { 0, 0, 0, 0, 2 },
                { 4, 5, 0, 0, 1 },
                { 3, 0, 0, 0, 0 },
                { 0, 5, 4, 2, 0 },
                { 0, 0, 3, 1, 0 },
            }; //bottom right 4,4

        private bool[,] hasColor;

        private int nRows;
        private int nCols;
        private int row;
        private int col;
        private int time;

        //parent of cells
        [SerializeField] Transform GridRoot;
        //template to populate gird
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject colorEnds;
        //[SerializeField] GameObject winLabel;
        //[SerializeField] TextMeshProUGUI timeLabel;

        bool redLineComplete;
        bool greenLineComplete;
        bool blueLineComplete;
        bool yellowLineComplete;
        bool purpleLineComplete;


        public Input input;
        private InputAction click;
        private InputAction move;

        private void Awake()
        {
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);

            //create bool[] w/ dimensions of grid
            hasColor = new bool[nRows, nCols];  
            //determines if a cell is already filled/blocked/has a color
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                { 
                    if (grid[i,j] > 0) hasColor[i,j] = true;    
                }
            }
            //finds where the ends of the colors are at the start and sets them as a different type of cell prefab
            //if no color, regular cell perfab
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    if (hasColor[i, j]) 
                    {
                        Instantiate(colorEnds, GridRoot);
                    }
                    else Instantiate(cellPrefab, GridRoot);
                }
            }
            //shows ends of the colors
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    row = i; col = j;
                    Transform cell = GetCurrentCell();
                    switch (grid[i,j])
                    {
                        case 1:
                            Transform red = cell.Find("Red");
                            red.gameObject.SetActive(true);
                            break;
                        case 2:
                            Transform green = cell.Find("Green");
                            green.gameObject.SetActive(true);
                            break;
                        case 3:
                            Transform blue = cell.Find("Blue");
                            blue.gameObject.SetActive(true);
                            break;
                        case 4:
                            Transform yellow = cell.Find("Yellow");
                            yellow.gameObject.SetActive(true);
                            break;
                        case 5:
                            Transform purple = cell.Find("Purple");
                            purple.gameObject.SetActive(true);
                            break;
                    }
                }
            }

            input = new Input();
            click = input.Player.Click;
            move = input.Player.Move;

            redLineComplete = false;
            greenLineComplete = false;
            blueLineComplete = false;
            yellowLineComplete = false;
            purpleLineComplete = false;
        }

        private void OnEnable()
        {
            click.Enable();
            click.performed += Click;
            move.Enable();
        }
        private void OnDisable()
        {
            click.Disable();
            move.Disable();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        Transform GetCurrentCell()
        {
            int index = (row * nCols) + col;
            return GridRoot.GetChild(index);
        }
        void SelectCurrentCell()
        { 
            Transform cell = GetCurrentCell();
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }
        void DeselectCurrentCell()
        {
            Transform cell = GetCurrentCell();
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }

        void MoveCell()
        { 
            
        }

        void Click(InputAction.CallbackContext context)
        {
            //called when player clicks
            //use to identify where the player clicked, if the cell is a starting cell, and 
            DeselectCurrentCell();
            SelectCurrentCell();
        }

    }

}
