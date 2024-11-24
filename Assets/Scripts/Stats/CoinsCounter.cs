using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Progress _progressController;
    
    [SerializeField] private int _value;
    [SerializeField] private TMP_Text _uiText;
    [SerializeField] private float _convertMoveToCoinsCoef;

    private void Start()
    {
        _value = _progressController.Coins;
        UpdateValue();
    }

    private void OnEnable()
    {
        EnemyReward.OnEnemyDefeated += IncreaseValue;
        PlayerMovement.OnMoveStopped += ConvertMoveToCoins;
    }

    private void OnDisable()
    {
        EnemyReward.OnEnemyDefeated -= IncreaseValue;
        PlayerMovement.OnMoveStopped -= ConvertMoveToCoins;
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

    private void ConvertMoveToCoins(int moveCount)
    {
        int reward = (int) (moveCount * _convertMoveToCoinsCoef);
        IncreaseValue(reward);
    }
}
