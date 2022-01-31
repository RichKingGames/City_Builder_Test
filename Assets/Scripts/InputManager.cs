using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private BuildingArea _buildingArea;
    [SerializeField]
    private InputListener _input;

    private Building _building;

    private bool _isBuilding = false;

    public void StartPlacement()
    {
        BuildingType buildingType = _buildingArea.Creator.GetRandomType();
        _building = _buildingArea.Creator.CreateBuilding(buildingType, _input.Position);
        _buildingArea.OnModeChange?.Invoke();
        _isBuilding = true;

        _input.CursorPosition += Move;
        _input.MousePressed += TryPlace;
        _input.EscapePressed += () => CancelPlacement(true);
    }

    public void CancelPlacement(bool withDestroy)
    {
        if (_isBuilding)
        {
            _isBuilding = false;
            _input.CursorPosition -= Move;
            _input.MousePressed -= TryPlace;
            _input.EscapePressed -= () => CancelPlacement(true) ;

            if (withDestroy)
                _buildingArea.CancelBuild(_building);
        }
    }

    void Move(Vector2 position)
    {
        if (_isBuilding)
        {
            _building.Move(position);
            CheckFits();
        }
    }

    private PlacingStatus CheckFits()
    {
        return _buildingArea.Fits(_building.Position, _building);
    }

    private void TryPlace()
    {
        if (_isBuilding && CheckFits() == PlacingStatus.Fits)
        {
            Place();
        }
    }

    private void Place()
    {
        _buildingArea.PlaceBuilding(_building, _building.Type);
        CancelPlacement(false);
    }
}
