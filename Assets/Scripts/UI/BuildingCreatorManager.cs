using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreatorManager : MonoBehaviour
{
    [SerializeField]
    private BuildingCreatorView _view;
    [SerializeField]
    private InputManager _inputManager;

    private IBuildingCreatorModel _model;
    private IBuildingCreatorController _controller;

    void Start()
    {
        _model = new BuildingCreatorModel(_inputManager);
        _controller = new BuildingCreatorController(_view, _model);
    }
}
