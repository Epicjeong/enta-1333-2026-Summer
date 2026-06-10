using UnityEngine;
using System.Collections.Generic;

public class NaivePathFinder
{
    private System.Func<Vector2Int, List<Vector2Int>> _getNeighbors;
    private bool _allowDiagonal;
    private int _maxPathLength;

    //contructor
    public NaivePathFinder(
        System.Func<Vector2Int, List<Vector2Int>> getNeighbors,
        bool allowDiagonal = true,
        int maxPathLength = 0)
    {
        this._getNeighbors = getNeighbors;
        this._allowDiagonal = allowDiagonal;
        this._maxPathLength = maxPathLength;
    }

    public (List<Vector2Int>path, HashSet<Vector2Int> visited) FindPath(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();
        Vector2Int current = start;
        path.Add(current);
        visited.Add(current);

        return(path, visited);

        while (current != end)
        {
            Vector2Int next;
            if (_allowDiagonal)
            {
                //later
            }
            else
            {
                next = GetCardinalNaivePosition(current, end);
            }
        }
    }

    private Vector2Int GetCardinalNaivePosition(Vector2Int current, Vector2Int target)
    {
        //which direction has the larger difference
        int dx = Mathf.Abs(target.x - current.x);
        int dy = Mathf.Abs(target.y - current.y);

        //try to move in direction of larger distance first
        if (dx > dy)
        {
            int signX = target.x > current.x ? 1 : -1;
            Vector2Int next = current + new Vector2Int(signX, 0);
            if (isValidMove(next))
            {
                return next;
            }

            //vertical if horizontal failed
            int signY = target.y > current.y ? 1 : -1;
            next = current + new Vector2Int(0, signY);
            if(isValidMove(next))
            {
                return next;
            }
        }
        else
        {
            //vertical moving
            int signY = target.y > current.y ? 1 : -1;
            Vector2Int next = current + new Vector2Int(0, dy);
            if (isValidMove(next))
            {
                return next;
            }

            //horizontal if vertical failed
            int signX = target.x > current.x ? 1 : -1;
            next = current + new Vector2Int(signX, 0);
            if (isValidMove(next))
            {
                return next;
            }
        }

            return current;
    }

    private bool isValidMove(Vector2Int pos)
    {
        return _getNeighbors(pos).Count > 0;
    }
}
