using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingArea : MonoBehaviour
{
    public GridGenerator GridGenerator;
    public BuildingCreator Creator;
    public JsonData Data;
    public GlowCell Glow;

    public UnityEvent OnModeChange;



    private void Start()
    {
        InitMap();
    }
    private void InitMap()
    {
        GridConfigReader config = new GridConfigReader();
        Data = config.ReadJson();

        GridGenerator.Init(Data.CellSize,Data.Width,Data.Height);

        Glow = new GlowCell(this);

        Creator.Init(Data.Buildings,Data.CellSize);
    }
    private Vector2Int ConvertPositionToGrid(Vector3 position)
    {
        Vector2 temp = new Vector2(position.x, position.z);
        Vector2Int result = new Vector2Int(Mathf.CeilToInt(temp.x / Data.CellSize), Mathf.CeilToInt(temp.y / Data.CellSize));
        
        return result;
    }

    public ICell GetTile(Vector2Int _gridPos)
    {
        //check the boundaries
        if (_gridPos.x < 0 || _gridPos.y < 0 || _gridPos.x > Data.Width || _gridPos.y > Data.Height || GridGenerator.Grid[_gridPos.x, _gridPos.y] == null)
        {
            Debug.Log("Out of bounds");
            return null;
        }
      
        return GridGenerator.Grid[_gridPos.x, _gridPos.y];
    }

    public PlacingStatus Fits(Vector3 buildingPosition, Building building)
    {
        Vector2Int _gridPos = ConvertPositionToGrid(buildingPosition);
        Vector2Int extents = new Vector2Int(_gridPos.x + building.Size, _gridPos.y + building.Size);

        if (_gridPos.x < 0 || _gridPos.y < 0 || extents.x > Data.Width || extents.y > Data.Height)
        {
            return PlacingStatus.OutOfBounds;
        }
        Glow.HighlightCell(_gridPos, building);

        for (int y = _gridPos.y-1; y < extents.y+1; y++)
        {
            for (int x = _gridPos.x-1; x < extents.x+1; x++)
            {
                if (!GridGenerator.IsEmptyCell(x,y))
                {
                    return PlacingStatus.Overlaps;
                }
            }
        }

        return PlacingStatus.Fits;
    }

  
    public void PlaceBuilding(Building building, BuildingType buildingType)
    {
        //buildings
        Creator.Buildings.Add(building);
        Glow.ResetGlow();     
        
        Vector2Int _gridPos = ConvertPositionToGrid(building.Position);

        Vector2Int extents = new Vector2Int(_gridPos.x + building.Size, _gridPos.y + building.Size);


        for (int y = _gridPos.y-1; y < extents.y+1; y++)
        {
            for (int x = _gridPos.x-1; x < extents.x+1; x++)
            {
                GridGenerator.SetEmpty(x, y, false);
            }
        }

        Vector2 positionForBuilding = new Vector2(_gridPos.x * Data.CellSize -(Data.CellSize/2), _gridPos.y * Data.CellSize - (Data.CellSize / 2));
        building.PlaceBuilding(OnModeChange, positionForBuilding, Creator.PowerManager.PlusPower);
    }
    public void CancelBuild(Building building)
    {
        Glow.ResetGlow();
        building.DestroyObject(OnModeChange);
        OnModeChange?.Invoke();
    }
}
