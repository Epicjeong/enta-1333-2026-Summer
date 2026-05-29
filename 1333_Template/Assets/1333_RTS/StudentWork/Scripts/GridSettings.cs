using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
/// <summary>
/// ForScriptable obhect for grid customization
/// </summary>
[CreateAssetMenu(fileName = "GridSettings", menuName = "Game/GridSettings")]
public class GridSettings : ScriptableObject
{
    [SerializeField] private int _gridSizeX = 10;
    [SerializeField] private int _gridSizeY = 10;
    [SerializeField] private float _nodesize = 1;
    [SerializeField] private bool _useXZPlane= true;

    public int GridSizeX => _gridSizeX;
    public int GridSizeY => _gridSizeY;
    public float NodeSize => _nodesize;
    public bool XZPlane => _useXZPlane;
}
