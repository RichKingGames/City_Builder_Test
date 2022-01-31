using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostState : MonoBehaviour, IState
{
    private Color _currentColor;
    private IState _goalState;
    private Building _building;
    public Color CurrentColor
    {
        get
        {
            return _currentColor;
        }
        set 
        {
            _currentColor = value;
        } 
    }
    public IState GoalState 
    {
        get
        {
            return _goalState;
        }
        set
        {
            _goalState = value;
        }
    }

    public Building Building
    { 
        get
        {
            return _building;
        }
        set
        {
            _building = value;
        }
    }

    public void EnterState()
    {
        Building.ChangeColor(CurrentColor);
    }



    public void InitializeState(Building building, IState goalState, Color currentColor)
    {
        Building = building;
        CurrentColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
        GoalState = goalState;
    }
}
