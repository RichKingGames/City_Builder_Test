using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowCell : MonoBehaviour
{
    private List<ICell> _glowCells;
    private BuildingArea _buildingArea;

    public GlowCell(BuildingArea buildingArea)
    {
        _buildingArea = buildingArea;
        _glowCells = new List<ICell>();
    }

    public void HighlightCell(Vector2Int _gridPos, Building _building)
    {
        ResetGlow();
        Vector2Int extents = new Vector2Int(_gridPos.x + _building.Size, _gridPos.y + _building.Size);

        for (int y = _gridPos.y-1; y < extents.y+1; y++)
        {
            for (int x = _gridPos.x-1; x < extents.x+1; x++)
            {
                ICell tile = _buildingArea.GetTile(new Vector2Int(x, y));
                if(tile!=null)
                {
                    tile.ChangeColor(true);
                    _glowCells.Add(tile);
                }
            }
        }
    }

    public void ResetGlow()
    {
        for (int i = _glowCells.Count - 1; i >= 0; i--)
        {
            _glowCells[i].ChangeColor(false);
            _glowCells.RemoveAt(i);
        }
    }
}
