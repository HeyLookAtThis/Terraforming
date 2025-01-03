using System.Collections.Generic;
using UnityEngine;

public class CircleCoordinateSystem
{
    private List<CircleAxis> _axis;

    public CircleCoordinateSystem(LevelBordersMarker marker)
    {
        Initialize(marker);
    }

    private float ArcLength => 7.85f;

    public void PlaceObject(IInteractiveObject interactiveObject, int currentLevel)
    {
        if (currentLevel < 3)
        {
            _axis[0].PlaceObject(FindEmptyCellIndex(_axis[0]), interactiveObject);
        }
        else if (currentLevel >= 3 && currentLevel < 7)
        {
            if (_axis[0].FreeCellsCount > 0)
            {
                _axis[0].PlaceObject(FindEmptyCellIndex(_axis[0]), interactiveObject);
            }
            else
            {
                _axis[1].PlaceObject(FindEmptyCellIndex(_axis[1]), interactiveObject);
            }
        }
        else if (currentLevel >= 7 && currentLevel < 13)
        {
            if (_axis[0].FreeCellsCount > 0)
            {
                _axis[0].PlaceObject(FindEmptyCellIndex(_axis[0]), interactiveObject);
            }
            else if(_axis[0].FreeCellsCount == 0 && _axis[1].FreeCellsCount > 0)
            {
                _axis[1].PlaceObject(FindEmptyCellIndex(_axis[1]), interactiveObject);
            }
            else
            {
                _axis[2].PlaceObject(FindEmptyCellIndex(_axis[1]), interactiveObject);
            }
        }
    }

    private int FindEmptyCellIndex(CircleAxis cells) => (int)Random.Range(0, cells.FreeCellsCount - 1);

    private void Initialize(LevelBordersMarker marker)
    {
        int axisCount = (int)((marker.Config.DistanceToEnd - marker.Config.DistanceToStart) / marker.Config.DistanceBetweenAxis);
        float radius = marker.Config.DistanceToStart;

        _axis = new List<CircleAxis>();

        for (int i  = 0; i < axisCount; i++)
        {
            CircleAxis axis = new CircleAxis(radius, ArcLength, marker);
            _axis.Add(axis);

            radius += marker.Config.DistanceBetweenAxis;
        }
    }
}
