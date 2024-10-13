using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Progress _progressController;
    
    [SerializeField] private int _value;
    [SerializeField] private TMP_Text _uiText;

    private void Start()
    {
        _value = _progressController.Coins;
        UpdateValue();
    }

    private void OnEnable()
    {
        EnemyReward.OnEnemyDefeated += IncreaseValue;
    }

    private void OnDisable()
    {
        EnemyReward.OnEnemyDefeated -= IncreaseValue;
    }

    private void IncreaseValue(int increase)
    {
        _value += increase;
        UpdateValue();
    }
    
    private void DecreaseValue(int decrease)
    {
        _value -= decrease;
        UpdateValue();
    }

    private void UpdateValue()
    {
        _uiText.text = _value.ToString();
        _progressController.Coins = _value;
    }
}
