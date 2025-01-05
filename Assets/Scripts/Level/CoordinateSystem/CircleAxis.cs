using System.Collections.Generic;
using UnityEngine;

public class CircleAxis
{
    private List<Cell> _cells;
    private List<Cell> _freeCells;

    public CircleAxis(float radius, LevelBordersMarker marker) => InitializeCoordinates(radius, marker);

    public bool IsFilled => _freeCells.Count == 0;
    private float ArcLength => 7.85f;

    public void PlaceObjectToRandomCell(IInteractiveObject interactiveObject)
    {
        int index = GetRandomCellIndex();

        _freeCells[index].Occupy(interactiveObject);
        _freeCells.RemoveAt(index);
    }

    public void ClearCells()
    {
        foreach (var cell in _cells)
            cell.Clear();

        ResetEmptyCells();
    }

    private void InitializeCoordinates(float radius, LevelBordersMarker levelBordersMarker)
    {
        _cells = new List<Cell>();

        float length = GetCircleLength(radius);
        float currentArcLength = ArcLength;
        int cellsCount = (int)(length / ArcLength);

        for (int i = 0; i < cellsCount; i++)
        {
            float angle = GetAngle(radius, currentArcLength);

            float xCoordinate = Mathf.Cos(angle * Mathf.Deg2Rad) * radius + levelBordersMarker.Center.x;
            float zCoordinate = Mathf.Sin(angle * Mathf.Deg2Rad) * radius + levelBordersMarker.Center.z;
            float yCoordinate = levelBordersMarker.GroundHeight;

            Vector3 position = new Vector3(xCoordinate, yCoordinate, zCoordinate);
            Cell cell = new Cell(position);
            _cells.Add(cell);

            currentArcLength += ArcLength;
        }

        ResetEmptyCells();
    }

    private float GetAngle(float radius, float acrLength) => acrLength / (Mathf.PI * radius) * 180f;
    private float GetCircleLength(float radius) => 2f * Mathf.PI * radius;
    private void ResetEmptyCells() => _freeCells = new List<Cell>(_cells);
    private int GetRandomCellIndex() => (int)Random.Range(0, _freeCells.Count - 1);
}
