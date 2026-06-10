using UnityEngine;

[CreateAssetMenu(fileName = "TerrainType", menuName = "TerrainType")]
public class TerrainType : ScriptableObject
{
    [SerializeField] private string _terrainName;
    [SerializeField] private Color _color;
    [SerializeField] private bool _walkable;
    [SerializeField] private int _moveCost;
    [SerializeField] private Texture2D _terrainTexture;

    public string TerrainName => _terrainName;
    public Color Color => _color;
    public bool Walkable => _walkable;
    public int MoveCost => _moveCost;
    public Texture2D TerrainTexture => _terrainTexture;
}
