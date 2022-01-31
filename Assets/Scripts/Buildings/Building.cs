using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private int _power;
    
    public BuildingType Type;

    public StateAutomat Automat;

    public int Size;
    
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        private set
        {
            transform.position = new Vector3(value.x, transform.position.y, value.y);
        }
    }

    private void Start()
    {
        Color currentColor = gameObject.GetComponentInChildren<Renderer>().material.color;
        Automat.InitializeStates(this,currentColor);
        Automat.TransitionToState(Automat.GetState(StateType.Proccess));
    }

    public void Init(int power, float height, int size, float cellSize)
    {
        _power = power;
        
        _text.text = _power.ToString();
        Size = size;
        gameObject.transform.localScale = new Vector3(size * cellSize, height, size * cellSize);
    }

    public void PlaceBuilding(UnityEvent onModeChange, Vector2 placedPosition, Action<int> plusPowerToManager)
    {
        onModeChange.AddListener(Automat.TransitionToGoalState);
        onModeChange?.Invoke();
        plusPowerToManager?.Invoke(_power);
        Position = placedPosition;
    }

    public void Move(Vector2 position)
    {
        Position = position;
    }

    public void ChangeColor(Color color)
    {
        gameObject.GetComponentInChildren<Renderer>().material.color = color;
    }

    public void DestroyObject(UnityEvent onModeChange)
    {
        onModeChange.RemoveListener(Automat.TransitionToGoalState);
        Destroy(this.gameObject);
    }
}
