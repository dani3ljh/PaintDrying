using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [Header("Grid Values")]
    [SerializeField] private float gridWidth;
    [SerializeField] private float gridHeight;
    [SerializeField] private uint numberCellsWidth;
    [SerializeField] private uint numberCellsHeight;

    [Header("GameObjects")]
    [SerializeField] private Transform cellFolder;

    [Header("Prefabs")]
    [SerializeField] private GameObject cellPrefab;
    
    private GameObject[,] board;
    private float[,] boardState; // true = wet, false = dry

    // Start is called before the first frame update
    void Start()
    {
        board = new GameObject[numberCellsHeight, numberCellsWidth];
        boardState = new float[numberCellsHeight, numberCellsWidth];

        float deltaW = gridWidth / numberCellsWidth;
        float deltaH = gridHeight / numberCellsHeight;

        for (int i = 0; i < numberCellsHeight; i++)
        {
            float y = (numberCellsHeight - 1) / 2f * deltaH - deltaH * i;
            for (int j = 0; j < numberCellsWidth; j++)
            {
                float x = -(numberCellsWidth - 1) / 2f * deltaW + deltaW * j;

                GameObject cell = Instantiate(cellPrefab, new Vector3(x, y, 0), cellPrefab.transform.rotation, cellFolder);
                RectTransform rect = cell.GetComponent<RectTransform>();

                rect.sizeDelta = new Vector2(deltaW, deltaH);
                rect.anchoredPosition = new Vector2(x, y);
                cell.layer = 0;

                board[i, j] = cell;
                boardState[i, j] = 1f;
            }
        }
    }
}
