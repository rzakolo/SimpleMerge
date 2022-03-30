using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIService : IDisposable
{
    private Image _progressBar;
    private Text _levelText;
    private Player _player;
    public UIService(Player player, Image progressBar, Text levelText)
    {
        _player = player;
        _progressBar = progressBar;
        _levelText = levelText;
        _player.OnExpEarn += ChangeExp;
        _player.OnLevelUp += ChangeLevel;
    }

    public void Dispose()
    {
        _player.OnExpEarn -= ChangeExp;
        _player.OnLevelUp -= ChangeLevel;
    }

    private void ChangeExp(float value)
    {
        _progressBar.fillAmount += value;
    }
    private void ChangeLevel(int value)
    {
        _progressBar.fillAmount = 0f;
        _levelText.text = value.ToString();
    }
}
