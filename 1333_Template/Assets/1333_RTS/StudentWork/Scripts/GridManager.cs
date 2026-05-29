using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    //variable for grid settings
    [SerializeField] private GridSettings _gridSettings;
    public GridSettings GridSettings => _gridSettings;

    //varibales for grid array to place nodes
    private GridNode[,] _gridNode;

    //flag to make sure grids initialized
    public bool IsInitialized { get; private set; } = false;

#if UNITY_EDITOR
    [Header("Debug for editor playmode")]
    [SerializeField] private List<GridNode> AllNodes = new();
#endif

    public void InitializeGrid()
    {
        //initializes grid from vars in grid settings
        _gridNode = new GridNode[_gridSettings.GridSizeX, _gridSettings.GridSizeY];

        //nested for for grids
        for (int x = 0; x < _gridSettings.GridSizeX; x++)
        {
            for (int y = 0; y < _gridSettings.GridSizeY; y++)
            {

            }
        }
    }

}
