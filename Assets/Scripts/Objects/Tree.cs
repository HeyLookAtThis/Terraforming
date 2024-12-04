using System.Collections;
using UnityEngine;

public class Tree : InteractiveObject, IInteractiveObject
{
    [SerializeField] private int _radius;
    [SerializeField] private TreeView _view;

    private GrassPainter _grassPainter;
    private Coroutine _grassPainterRunner;

    public Transform Transform { get => transform; set => transform.position = value.position; }
    private int GrassPainterRadiusMultiplier => 10;

    public override void ReactToScanner()
    {
        base.ReactToScanner();
        MakeGreen();
    }

    public override void ReturnToDefaultState()
    {
        base.ReturnToDefaultState();
        Destroy(gameObject);
    }

    public void Initialize(GrassPainter grassPainter) => _grassPainter = grassPainter;

    private void MakeGreen()
    {
        if (UsedByPlayer == false)
        {
            TurnOnUsed();
            _view.MakeGreen();
            UseObjectsAround();
        }
    }

    private void UseObjectsAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent<InteractiveObject>(out InteractiveObject interationObject))
                interationObject.ReactToScanner();

        RunGrassPainter();
    }

    private void RunGrassPainter()
    {
        if(_grassPainterRunner != null)
            StopCoroutine(_grassPainterRunner);

        _grassPainterRunner = StartCoroutine(PainterRunner());
    }

    private IEnumerator PainterRunner()
    {
        float runtime = 1f;
        var waitForEndOfFrame = new WaitForEndOfFrame();
        float passedTime = 0f;

        while(passedTime < runtime)
        {
            _grassPainter.Draw(transform.position, _radius * GrassPainterRadiusMultiplier);
            passedTime += Time.deltaTime;
            yield return waitForEndOfFrame;
        }

        if (passedTime >= runtime)
            yield break;
    }
}