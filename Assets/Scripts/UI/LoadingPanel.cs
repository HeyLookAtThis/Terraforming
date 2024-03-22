using UnityEngine;

public class LoadingPanel : Panel
{
    [SerializeField] private LoadingBar _bar;

    public LoadingBar Bar => _bar;
}
