using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public Building Building { get; set; }
    public Color CurrentColor { get; set; }

    public IState GoalState { get; set; }

    public void InitializeState(Building building,IState goalState, Color currentColor);
    public void EnterState();
}
