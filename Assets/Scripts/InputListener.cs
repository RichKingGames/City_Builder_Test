using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputListener : MonoBehaviour
{
    private Vector2 _lastPosition = Vector2.zero;

    private Building _selectedBuilding;

    private bool IsPressed;

    public event Action MousePressed;

    public event Action<Vector2> CursorPosition;

    public event Action EscapePressed;

    public Vector2 Position
    {
        get
        {
            return _lastPosition;
        }
    }

    void Update()
    {
        IsPressed = Input.GetMouseButtonDown(0) && !IsOnUI();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, 50f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (i == 0)
                CursorPosition?.Invoke(GetPosition(hits[i]));

            _selectedBuilding = SelectObject(hits[i]);
        }

        if (IsPressed)
            MousePressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.Escape))
            EscapePressed?.Invoke();
        
    }

    private Building SelectObject(RaycastHit _hit)
    {
        return _hit.transform.GetComponent<Building>();
    }

    private Vector2 GetPosition(RaycastHit _hit)
    {
        return new Vector2(_hit.point.x, _hit.point.z); 
    }

    private bool IsOnUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
