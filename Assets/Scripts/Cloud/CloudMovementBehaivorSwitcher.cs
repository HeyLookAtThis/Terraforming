using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudMovementBehaivorSwitcher
{
    private Transform _target;
    private Cloud _cloud;

    private List<IMover> _movers;
    private IMover _currentMover;

    public CloudMovementBehaivorSwitcher(Cloud cloud,Transform target)
    {
        _target = target;
        _cloud = cloud;

        _movers = new List<IMover>
        {
            new WateringCloudMover(_cloud.transform, _target),
            new EmptyCloudMover(_cloud.transform, _target, _cloud.Config.EmptyCloudConfig),
            new CloudToCharacterMover(_cloud.transform, _target, _cloud.Config.CloudToChatacterMoverConfig)
        };

        WateringCloudMover = _movers.First(mover => mover is WateringCloudMover);
    }

    public IMover CurrentMover => _currentMover;
    public IMover WateringCloudMover { get; private set; }

    public void SetMover<T>() where T : IMover
    {
        IMover iMover = _movers.FirstOrDefault(mover => mover is T);

        _currentMover?.StopMove();
        _currentMover = iMover;
        _currentMover.StartMove();
    }
}
