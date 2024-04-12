using System.Collections;
using UnityEngine;

public class Grass : LevelObject
{
    [SerializeField] private float _growSpeed;
    [SerializeField] private GameObject _model;

    private Coroutine _grower;

    protected override void Awake()
    {
        base.Awake();
        _model.SetActive(false);
    }

    public override void ReactToScanner(PlayerObjectsCounter player)
    {
        MakeVisible();
    }

    public override void ReturnToDefaultState()
    {
        _model.SetActive(false);

        float zeroHeight = 0;
        ChangeHeight(zeroHeight);
        TurnOffUsed();
    }

    private void MakeVisible()
    {
        if (WasUsedByPlayer == false)
        {
            _model.SetActive(true);

            BeginToGrow();
            TurnOnUsed();
        }
    }

    private void BeginToGrow()
    {
        if (_grower != null)
            StopCoroutine(_grower);

        _grower = StartCoroutine(GrowBeginner());
    }

    private IEnumerator GrowBeginner()
    {
        var WaitTime = new WaitForEndOfFrame();
        float minHeight = 1f;
        float currentHeight = 0;
        float height = Random.value + minHeight;

        while (currentHeight < height)
        {
            currentHeight += _growSpeed * Time.deltaTime;
            ChangeHeight(currentHeight);
            yield return WaitTime;
        }

        if (currentHeight >= height)
        {
            yield break;
        }
    }

    private void ChangeHeight(float height)
    {
        float horizontalSize = 2f;

        if (height > 0 && height < 1)
            _model.transform.localScale = new Vector3(horizontalSize, height, horizontalSize);
    }
}