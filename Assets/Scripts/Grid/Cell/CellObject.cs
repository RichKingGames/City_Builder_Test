using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : ICell
{
    private GameObject _prefab;

    private Color _mainColor;

    public bool IsEmpty { get; set; }
    public GameObject SetPrefab 
    {
        get
        {
            return _prefab;
        }
        set 
        {
            _prefab = value;
            _mainColor = PrefabColor;
        } 
    }

    public Color EmptyColor { get { return Color.green; } }
    public Color OccupiedColor { get { return Color.red; } }
    

    public Color PrefabColor 
    {
        get
        {
            return _prefab.GetComponent<Renderer>().material.color;
        }
        set 
        {
            _prefab.GetComponent<Renderer>().material.color = value; 
        } 
    }

    public CellObject()
    {
        IsEmpty = true;
    }

    public void ChangeColor(bool change)
    {
        if(_prefab)
        {
            if (change)
            {
                if (IsEmpty)
                    PrefabColor = EmptyColor;
                else
                    PrefabColor = OccupiedColor;
            }
            else
                PrefabColor = _mainColor;
        }
    }

}
