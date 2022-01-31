using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICell
{
    public GameObject SetPrefab { get; set; }
    public bool IsEmpty { get; set; }

    
    public Color EmptyColor { get;}
    public Color OccupiedColor { get;}

    public Color PrefabColor { get; set; }

    public void ChangeColor(bool changed);
}
