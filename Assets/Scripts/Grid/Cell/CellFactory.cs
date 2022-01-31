using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFactory : MonoBehaviour
{
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    private GameObject _cellPrefab;

    public ICell Create(int x, int z, float size)
    {
        ICell cell = new CellObject
        {
            SetPrefab = Instantiate(_cellPrefab, new Vector3(x * size, _parent.position.y, z * size),
            Quaternion.identity, _parent)
            //можно было бы сделать пул объектов, но не стал,
            //т.к. один раз в игре инстанциализируются клетки
        };

        cell.SetPrefab.transform.localScale = new Vector3(size, 0.1f, size);
        return cell;
    }
}

