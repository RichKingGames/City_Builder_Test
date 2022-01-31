using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private CellFactory CellFactory;
    [SerializeField]
    private BoxCollider rayCastCollider;

    private int _width = 0;
    private int _height = 0;

    public ICell[,] Grid;

    public void Init(float cellSize, int width, int height)
    {
        _width = width;
        _height = height;
        Grid = Generate(CellFactory, rayCastCollider, cellSize, _width, _height);
    }
    public void SetEmpty(int x, int y,bool isEmpty)
    {
        if (x < 0 || y < 0 || x > _width || y > _height )
        {
            Debug.Log("Out of bounds");
            return;
        }

        Grid[x, y].IsEmpty = isEmpty;
    }

    public bool IsEmptyCell(int x, int y)
    {
        if (x < 0 || y < 0 || x > _width || y > _height)
        {
            Debug.Log("Out of bounds");
            return false;
        }

        return Grid[x,y].IsEmpty;
    }
    
    public ICell[,] Generate(CellFactory cellFactory, BoxCollider collider, float cellSize, int width, int height)
    {
        ICell[,] result = new ICell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                result[x, z] = cellFactory.Create(x, z, cellSize);
            }
        }

        collider.transform.position += new Vector3(width * cellSize / 2, 0, height * cellSize / 2);
        collider.size = new Vector3(width * cellSize, collider.size.y , height * cellSize);

        return result;
    }
}
