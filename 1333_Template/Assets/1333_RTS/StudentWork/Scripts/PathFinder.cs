using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

public class PathFinder : MonoBehaviour 
{
    public enum PathFindingType
    {
        Naive
    }

    public enum VisualizationState
    {
        Idle,
        Eploring,
        Recontructing,
        Paused
    }

    [Header("Required Reference")]
    [SerializeField] private GridManager _gridManager;

    [Header("Pathfinding Settings")]
    [SerializeField] private PathFindingType _pathFindingType = PathFindingType.Naive;
    [SerializeField, Range(0, 100)] private int _framesPerStep = 10;
    [SerializeField] private bool _visualizePath = true;

    [Header("Visualize Colors")]
    [SerializeField] private Color _startingColor = Color.green;
    [SerializeField] private Color _endingColor = Color.red;
    [SerializeField] private Color _pathColor = Color.yellow;
    [SerializeField] private Color _visitedColor = new Color(.5f, .5f, 1, .5f);
    [SerializeField] private Color _unvisitedColor = new Color(.3f, .3f, .3f, .3f);
    [SerializeField] private Color _finalPath = Color.cyan;
    [SerializeField] private Color _currentNodeColor = Color.magenta;
    [SerializeField] private Color _neighbor = new Color(1f, .5f, 0, .5f);
    [SerializeField] private Color _exploreLine = new Color(1f, 1f, 0, .3f);

    [Header("Visual Settings")]
    [SerializeField] private int _currentSeed = 0;
    [SerializeField] private bool _useSeededRandom = true;
    [SerializeField] private float _minWieght = 1f;
    [SerializeField] private float _maxWieght = 10f;

    //PathFinder instances
    private NaivePathFinder _naivePathFinder;

    //Viusalize instance
    private NaivePathFinderVisualizer _naivePathFinderVisualizer;
}
