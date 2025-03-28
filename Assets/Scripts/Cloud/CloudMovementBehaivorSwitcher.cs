using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudMovementBehaivorSwitcher
{
    private Cloud _cloud;
    private List<IMover> _movers;

    public CloudMovementBehaivorSwitcher(Cloud cloud,Transform target)
    {
        _cloud = cloud;
        WateringCloudMover wateringCloudMover = new WateringCloudMover(cloud.transform, target);

        _movers = new List<IMover>
        {
            wateringCloudMover,
            new EmptyCloudMover(cloud.transform, target, cloud.Config.EmptyCloudConfig),
            new CloudToCharacterMover(cloud.transform,target, cloud.Config.CloudUnderChatacterConfig)
        };

        WateringCloudMover = wateringCloudMover;
        SetMover<WateringCloudMover>();
    }

    public WateringCloudMover WateringCloudMover { get; private set; }

    public void SetMover<T>() where T : IMover
    {
        IMover iMover = _movers.FirstOrDefault(mover => mover is T);
        _cloud.SetMover(iMover);
    }
}
