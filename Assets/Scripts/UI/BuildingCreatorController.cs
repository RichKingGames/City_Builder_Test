using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreatorController : IBuildingCreatorController
{
    readonly IBuildingCreatorView _view;
    readonly IBuildingCreatorModel _model;

    public BuildingCreatorController(IBuildingCreatorView view, IBuildingCreatorModel model)
    {
        _view = view;
        _view.Controller = this;
        _model = model;
    }

    public void StartCreate()
    {
        _model.StartCreate();
    }
}