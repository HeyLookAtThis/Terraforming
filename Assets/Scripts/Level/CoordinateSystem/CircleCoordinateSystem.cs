using System.Collections.Generic;
using System.Linq;

public class CircleCoordinateSystem
{
    private List<CircleAxis> _axis;

    public CircleCoordinateSystem(LevelBordersMarker marker) => Initialize(marker);

    public void PlaceObject(IInteractiveObject interactiveObject)
    {
        var axis = _axis.FirstOrDefault(axis => axis.IsFilled == false);
        axis.PlaceObjectToRandomCell(interactiveObject);
    }

    public void Clear()
    {
        foreach(var axis in _axis)
            axis.ClearCells();
    }

    private void Initialize(LevelBordersMarker marker)
    {
        int axisCount = (int)((marker.Config.DistanceToEnd - marker.Config.DistanceToStart) / marker.Config.DistanceBetweenAxis);
        float radius = marker.Config.DistanceToStart;

        _axis = new List<CircleAxis>();

        for (int i  = 0; i <= axisCount; i++)
        {
            CircleAxis axis = new CircleAxis(radius, marker);
            _axis.Add(axis);

            radius += marker.Config.DistanceBetweenAxis;
        }
    }
}
