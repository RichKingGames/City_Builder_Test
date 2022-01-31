using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreatorModel : IBuildingCreatorModel
{
    private readonly InputManager _inputManager;


    public BuildingCreatorModel(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public void StartCreate()
    {
        _inputManager.CancelPlacement(true);
        _inputManager.StartPlacement();
    }
}
