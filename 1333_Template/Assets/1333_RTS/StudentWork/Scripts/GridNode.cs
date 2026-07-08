using UnityEngine;
/// <summary>
/// Represents nodes on grid, lightweight
/// </summary>
[System.Serializable]
public struct GridNode
{
    public TerrainType _terrainType;
    public string Name; //index to keep track/note
    public Vector3 WorldPos;
    public bool Walkable => _terrainType != null && _terrainType.Walkable;
    public int Weight => _terrainType != null ? _terrainType.MoveCost : 1;
    public Color Color => _terrainType != null ? _terrainType.Color: Color.gray;

    void Awake()
    {

    }
}
