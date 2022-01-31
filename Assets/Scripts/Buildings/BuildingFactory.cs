using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _buildingPrefab;
    [SerializeField]
    private Transform _parent;
    
    public Building Create(BuildingType type, Vector2 position)
    {
        GameObject building = Instantiate(_buildingPrefab, new Vector3(position.x, 0, position.y),
            Quaternion.identity, _parent);
        return building.GetComponent<Building>();
    }

}
