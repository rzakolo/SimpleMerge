using System;
using UnityEngine;

public class Player
{
    public event Action<float> OnExpEarn;
    public event Action<int> OnLevelUp;
    public int PotionExp = 10;
    public int MaxPlayerLevel = 10;


    private int _playerLevel;
    private int _playerCurrentExp;
    private int _requiredExp = 20;

    public void GetExp()
    {
        _playerCurrentExp += PotionExp;
        float exp = (float)PotionExp / _requiredExp;
        OnExpEarn?.Invoke(exp);
        if (_playerCurrentExp >= _requiredExp)
        {
            LevelUp();
            _playerCurrentExp = 0;
        }
    }
    private void LevelUp()
    {
        if (_playerLevel < MaxPlayerLevel)
        {
            _playerLevel++;
            OnLevelUp?.Invoke(_playerLevel);
            _requiredExp *= 2;
        }
    }
}
