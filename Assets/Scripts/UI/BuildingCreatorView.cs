using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCreatorView : MonoBehaviour, IBuildingCreatorView
{
    [SerializeField]
    private Button _buildButton;

    private IBuildingCreatorController _controller;

    public IBuildingCreatorController Controller
    {
        set
        {
            _controller = value;
        }
    }

    private void Start()
    {
        _buildButton.onClick.AddListener(_controller.StartCreate);
    }

    public bool MenuIsOpen()
    {
        return gameObject.activeSelf;
    }


    private void OnDestroy()
    {
        _buildButton.onClick.RemoveAllListeners();
        
    }

}
