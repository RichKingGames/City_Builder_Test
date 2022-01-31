using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    
    private BuildingData[] _data;

    private float _cellSize;

    private List<BuildingType> _types;

    public BuildingFactory Factory;
    public List<Building> Buildings;

    public PowerManager PowerManager;

    public void Init(BuildingData[] data, float cellSize)
    {
        Buildings = new List<Building>();
        _types = new List<BuildingType>();
        _data = data;
        _cellSize = cellSize;

        foreach (var item in _data)
        {
            if(!_types.Contains(item.Type) && item.Type<=BuildingType.Bank)
                _types.Add(item.Type);
        }
    }

    public BuildingType GetRandomType()
    {
        return _types[Random.Range(0, _types.Count)];
    }
    public Building CreateBuilding(BuildingType type, Vector2 position)
    {
        Building building = Factory.Create(type, position);

        foreach (var item in _data)
        {
            if (item.Type == type)
            {
                building.Init(item.Power, item.Height, item.Size, _cellSize);
                break;
            }
        }

        return building;     
    }
}
