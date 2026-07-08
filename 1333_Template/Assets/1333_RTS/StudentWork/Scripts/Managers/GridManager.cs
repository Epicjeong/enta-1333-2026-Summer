
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class GridManager : MonoBehaviour
{
    //variable for grid settings
    [SerializeField] private GridSettings _gridSettings;
    public GridSettings GridSettings => _gridSettings;
    [SerializeField] private TerrainType _defaultTerrainType;

    //varibales for grid array to place nodes
    private GridNode[,] _gridNode;

    //flag to make sure grids initialized
    public bool IsInitialized { get; private set; } = false;

    public bool _allowDiagonal;

#if UNITY_EDITOR
    [Header("Debug for editor playmode")]
    [SerializeField] private List<GridNode> AllNodes = new();
    [SerializeField] private bool _showGrid = true;
    [SerializeField] private bool _showNodeInfo;
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
                    _terrainType = _defaultTerrainType
                };

                _gridNode[x, y] = node;
            }
        }
        IsInitialized = true;
    }

    public void SetTerrainType(int x, int y, TerrainType terrain)
    {
        if (!IsValidCoord(x, y)) return;
        //pull node from array and sets terraintype, then put back in array
        GridNode node = _gridNode[x, y];
        node._terrainType = terrain;
        _gridNode[x, y] = node;
    }

    private bool IsValidCoord(int x, int y)
    {
        return x >=0 && x < _gridSettings.GridSizeX && y >= 0 && y < _gridSettings.GridSizeY;
    }

    public bool IsWalkable(Vector2Int coord)
    {
        if(IsValidCoord(coord.x, coord.y)) return true;
        return _gridNode[coord.x, coord.y].Walkable;
    }

    public float GetNodeWeight(Vector2Int coord)
    {
        if (!IsValidCoord(coord.x, coord.y)) return float.MaxValue;
        return _gridNode[coord.x, coord.y].Weight;
    }
#if UNITY_EDITOR
    private void PopulateDebugList()
    {
        //clears debug list of gridnodes, for each prexisting one get its info and sets it to the new gridnode
        //for debug stuff
        AllNodes.Clear();
        for (int x = 0; x < _gridSettings.GridSizeX; x++)
        {
            for (int y = 0; y < _gridSettings.GridSizeY; y++)
            {
                GridNode node = _gridNode[x, y];
                AllNodes.Add(_gridNode[x, y]);

            }

        }
    }

    //cutom editor button that calls populate debug list and resets gui
    [CustomEditor(typeof(GridManager))]
    public class GridManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //draws normal inspector gui
            DrawDefaultInspector();

            //looks at gridmanager attached to and calls populatedebuglisst function
            GridManager grid = (GridManager)target;
            if (grid.IsInitialized)
            {
                if (GUILayout.Button("refresh grid debug view"))
                {
                    grid.PopulateDebugList();
                }
            }
        }
    }
#endif

    //retrieves gridnode data efficiently
    public GridNode GetNode(int x, int y)
    {
        //checks if function arguemetns are out og bounds
        //otherwise returns the right node
        if(IsValidCoord(x, y))
        {
            throw new System.IndexOutOfRangeException("Grid mode indices out of range");
        }
        return _gridNode[x, y];
    }

    //for if nodes are walkable, not used at the moment
    //public void SetWalkable(int x, int y, bool walkable)
    //{
    //    _gridNode[x, y].Walkable = walkable;
    //}

    //visual gizmos togglable in editor
    private void OnDrawGizmos()
    {
        if (!_showGrid || _gridNode == null || _gridSettings == null) return;


        //draw node gizmos, size is 90% node size for visibility
        for (int x = 0; x < _gridSettings.GridSizeX; x++)
        {
            for (int y = 0; y < _gridSettings.GridSizeY; y++)
            {
                GridNode node = _gridNode[x, y];
                Gizmos.color = node.Color;
                Gizmos.DrawWireCube(node.WorldPos, Vector3.one * GridSettings.NodeSize * 0.9f);
#if UNITY_EDITOR
                if (_showNodeInfo)

                    Handles.Label(node.WorldPos + Vector3.up * .1f, $"{x}, {y}");
#endif
            }

        }
    }

    
}
