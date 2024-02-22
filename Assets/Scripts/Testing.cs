using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid<HeatMapGridObject> grid;
    private void Start() {
        //create new grid<type>(rows, cols, cellSize, offset(x, y), type)
        grid = new Grid<HeatMapGridObject>(20, 8, 1f, new Vector3(-11, -4), (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
            if (heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }
        }
    }
}

public class HeatMapGridObject
{
    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    public int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x; 
        this.y = y;
    }
    public void AddValue(int addValue) 
    { 
        value += addValue;
        Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}