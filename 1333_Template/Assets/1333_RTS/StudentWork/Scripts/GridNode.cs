using UnityEngine;
/// <summary>
/// Represents nodes on grid, lightweight
/// </summary>
[System.Serializable]
public struct GridNode
{
    public string Name; //index to keep track/note
    public Vector3 WorldPos;
    public bool Walkable;
    public int Weight;

    void Awake()
    {

    }
}
