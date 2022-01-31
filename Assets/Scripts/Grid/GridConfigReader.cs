using System;
using System.IO;
using UnityEngine;

public class GridConfigReader 
{
    private const string PATH ="/Data/Config/game_config.json";

    public GridConfigReader()
    {
        //BuildingData building1 = new BuildingData()
        //{
        //    Type = BuildingType.House,
        //    Height = 4f,
        //    Power = 100,
        //    Size = 2
        //};
        //BuildingData building2 = new BuildingData()
        //{
        //    Type = BuildingType.Office,
        //    Height = 30f,
        //    Power = 1000,
        //    Size = 4
        //};
        //BuildingData building3 = new BuildingData()
        //{
        //    Type = BuildingType.Bank,
        //    Height = 5f,
        //    Power = 500,
        //    Size = 3
        //};

        //JsonData data = new JsonData()
        //{
        //    CellSize = 0.5f,
        //    Height = 10,
        //    Width = 10,
        //    Buildings = new BuildingData[]
        //    {
        //        building1, building2, building3
        //    }
        //};

        //ToJSON(data);

    }

    public void ToJSON(JsonData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + PATH, json);
    }
    public JsonData ReadJson()
    {
        JsonData data;
        string json = File.ReadAllText(Application.dataPath + PATH);
        data = JsonUtility.FromJson<JsonData>(json);

        return data;

    }
}

[Serializable]
public class JsonData
{
    public float CellSize;
    public int Width;
    public int Height;
    public BuildingData[] Buildings;
}

[Serializable]
public class BuildingData
{
    public BuildingType Type;
    public int Size;
    public float Height;
    public int Power;
}

