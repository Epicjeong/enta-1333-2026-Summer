using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

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
        //new grid mode struct at each grid pos, gives default values and adds to gridnodes array
        for (int x = 0; x < _gridSettings.GridSizeX; x++)
        {
            for (int y = 0; y < _gridSettings.GridSizeY; y++)
            {
                //this is just an if else statement
                //? result is true, : is false
                Vector3 worldPos = GridSettings.XZPlane 
                    ? new Vector3(x, 0, y) * _gridSettings.NodeSize
                    : new Vector3(x, y, 0) * _gridSettings.NodeSize;

                GridNode node = new GridNode
                {
                    Name = $"Cell_{(x + _gridSettings.GridSizeX * x + y)}",
                    WorldPos = worldPos,
                    Walkable = true, //all nodes now default to walkable
                    Weight = 1 //default weight for terrain
                };

                _gridNode[x, y] = node;
            }
        }
    }

}
