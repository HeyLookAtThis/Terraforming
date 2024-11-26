using UnityEngine;

public class Resizer : CloudWaterIndicator
{
    private float _maxSize;
    private float _minSize;
    private float _currentSize;

    private float _increaseSpeed;
    private float _decreaseSpeed;

    public Resizer(Cloud cloud) : base(cloud)
    {
        _maxSize = cloud.Config.CloudUnderChatacterConfig.MaxSize;
        _minSize = cloud.Config.CloudWateringConfig.MinSize;
        _currentSize = _maxSize;

        _increaseSpeed = cloud.Config.CloudUnderChatacterConfig.FillingSpeed;
        _decreaseSpeed = cloud.Config.CloudWateringConfig.DecreaseSpeed;

        SetSize();
    }

    protected override void OnIncreaseValue()
    {
        if (_currentSize < _maxSize)
        {
            _currentSize += _increaseSpeed * Time.deltaTime;
            SetSize();
        }
    }

    protected override void OnDecreaseValue()
    {
        if (_currentSize > _minSize)
        {
            _currentSize -= _decreaseSpeed * Time.deltaTime;
            SetSize();
        }
    }

    private void SetSize() => Cloud.transform.localScale = new Vector3(_currentSize, _currentSize, _currentSize);
}
