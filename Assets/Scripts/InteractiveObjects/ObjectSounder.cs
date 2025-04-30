using System;
using UnityEngine;

public class ObjectSounder : IDisposable
{
    private AudioSource _audioSource;
    private GamePanel _gamePanel;

    public ObjectSounder(AudioSource audioSource, GamePanel gamePanel)
    {
        _audioSource = audioSource;
        _gamePanel = gamePanel;

        _gamePanel.Enabled += OnPlay;
        _gamePanel.Disabled += OnStop;
    }

    public void Dispose()
    {
        _gamePanel.Enabled -= OnPlay;
        _gamePanel.Disabled -= OnStop;
    }

    private void OnPlay() => _audioSource.Play();
    private void OnStop() => _audioSource.Stop();
}
