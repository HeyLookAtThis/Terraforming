using DG.Tweening;
using UnityEngine;

public class PlayerStarterPositionTaker : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private Water _water;

    private Vector3 _coordinates;

    private void Awake()
    {
        float height = 4f;
        _coordinates = new Vector3(_water.transform.position.x, height, _water.transform.position.z);
    }

    private void OnEnable()
    {
        _ground.Overheated += OnRun;
    }

    private void OnDisable()
    {
        _ground.Overheated -= OnRun;
    }

    private void OnRun()
    {
        transform.DOLocalMove(_coordinates, 0);
    }
}
