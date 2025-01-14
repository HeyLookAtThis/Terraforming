using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Resizer
{
    private float _maxSize;
    private float _minSize;
    private float _currentSize;

    private float _increaseSpeed;
    private float _decreaseSpeed;

    private Transform _cloud;
    private CloudView _view;

    private UnityAction _waterIsOver;
    private Coroutine _increaser;

    public Resizer(CloudConfig config, Transform cloud, CloudView cloudView)
    {
        _cloud = cloud;

        _maxSize = config.CloudUnderChatacterConfig.MaxSize;
        _minSize = config.CloudWateringConfig.MinSize;
        _currentSize = _maxSize;

        _increaseSpeed = config.CloudUnderChatacterConfig.IncreaseSpeed;
        _decreaseSpeed = config.CloudWateringConfig.DecreaseSpeed;

        _view = cloudView;

        SetSize();
    }

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    public bool HaveWater => _currentSize > 0;

    public void SetDefault() => _cloud.localScale = Vector3.one;

    public void OnDecrease()
    {
        if (_currentSize > _minSize)
        {
            _view.PlayRain();
            _currentSize -= _decreaseSpeed * Time.deltaTime;
            SetSize();
        }
        else
        {
            _view.StopRain();
            _currentSize = _minSize;
            SetSize();

            _waterIsOver?.Invoke();
        }
    }

    public void OnStartIncrease()
    {
        if (_currentSize < _maxSize)
        {
            _view.PlayFillingUp();
            _currentSize += _increaseSpeed * Time.deltaTime;
            SetSize();
        }
    }

    public void OnStopIncrease()
    {
        _view.StopFillingUp();

        if (_currentSize >= _maxSize)
        {
            _currentSize = _maxSize;
            SetSize();
        }
    }

    private void SetSize() => _cloud.localScale = new Vector3(_currentSize, _currentSize, _currentSize);
}
