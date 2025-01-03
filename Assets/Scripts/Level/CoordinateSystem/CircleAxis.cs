using System.Collections.Generic;
using UnityEngine;

public class CircleAxis
{
    private List<Cell> _cells;
    private List<Cell> _emptyCell;

    public CircleAxis(float radius, float arcLength, LevelBordersMarker marker)
    {
        Initialize(radius, arcLength, marker);
    }

    public int FreeCellsCount => _emptyCell.Count;

    public void PlaceObject(int index, IInteractiveObject interactiveObject)
    {
        if(index < _cells.Count)
        {
            _cells[index].Occupy(interactiveObject);
            _emptyCell.RemoveAt(index);
        }
    }

    public void ClearCells()
    {
        foreach (var cell in _cells)
            cell.Clear();

        ResetEmptyCells();
    }

    private void Initialize(float radius, float arcLength, LevelBordersMarker levelBordersMarker)
    {
        _cells = new List<Cell>();

        float length = GetCircleLength(radius);
        float currentArcLength = arcLength;
        int cellsCount = (int)(length / arcLength);

        for (int i = 0; i < cellsCount; i++)
        {
            float angle = GetAngle(radius, currentArcLength);

            float xCoordinate = Mathf.Cos(angle * Mathf.Deg2Rad) * radius + levelBordersMarker.Center.x;
            float zCoordinate = Mathf.Sin(angle * Mathf.Deg2Rad) * radius + levelBordersMarker.Center.z;
            float yCoordinate = levelBordersMarker.GroundHeight;

            Vector3 position = new Vector3(xCoordinate, yCoordinate, zCoordinate);
            Cell cell = new Cell(position);
            _cells.Add(cell);

            currentArcLength += arcLength;
        }

        ResetEmptyCells();
    }

    private float GetAngle(float radius, float acrLength) => acrLength / (Mathf.PI * radius) * 180f;
    private float GetCircleLength(float radius) => 2f * Mathf.PI * radius;
    private void ResetEmptyCells() => _emptyCell = new List<Cell>(_cells);
}
