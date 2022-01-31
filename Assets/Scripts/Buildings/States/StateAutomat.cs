using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAutomat : MonoBehaviour
{
    [SerializeField]
    private ProcessState Proccess;
    [SerializeField]
    private PlacedState Placed;
    [SerializeField]
    private GhostState Ghost;

    public IState CurrentState;
    
    public IState GetState(StateType type) => type switch
    {
        StateType.Proccess => Proccess,
        StateType.Placed => Placed,
        StateType.Ghost => Ghost,
        _ => throw new System.Exception("State nor defined " + type.ToString())
    };
    public void TransitionToState(IState goalState)
    {
        CurrentState = goalState;
        CurrentState.EnterState();
    }
    public void TransitionToGoalState()
    {
        IState goalState = CurrentState.GoalState;
        CurrentState = goalState;
        CurrentState.EnterState();
    }

    internal void InitializeStates(Building building,Color currentColor)
    {
        Proccess.InitializeState(building, Placed,currentColor);
        Placed.InitializeState(building, Ghost, currentColor);
        Ghost.InitializeState(building, Placed, currentColor);
    }
}
public enum StateType
{
    Proccess, 
    Placed, 
    Ghost
}