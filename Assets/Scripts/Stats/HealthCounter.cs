using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
    public class HealthCounter : MonoBehaviour
    {
        [SerializeField] private Progress _progressController;
        [SerializeField] private MenuController _menuController;
    
        [SerializeField] private int _value;
        [SerializeField] private TMP_Text _uiText;

        private const int ValueMaxCount = 5;

        private void OnEnable()
        {
            HealthPotion.OnHealthCollected += IncreaseValue;
            EnemyFight.OnEnemyFought += DecreaseValue;
        }

        private void OnDisable()
        {
            HealthPotion.OnHealthCollected -= IncreaseValue;
            EnemyFight.OnEnemyFought -= DecreaseValue;
        }

        void Start()
        {
            _value = _progressController.Health;
            UpdateValue();
        }

        private void IncreaseValue(int increase)
        {
            _value += increase;

            if (_value >= ValueMaxCount)
            {
                _value = ValueMaxCount;
            }
            
            UpdateValue();
        }

        private void DecreaseValue(int decrease)
        {
            _value -= decrease;

            if (_value <= 0)
            {
                _value = 0;
            }
            
            UpdateValue();
            _menuController.Dead();
        }

        private void UpdateValue()
        {
            _uiText.text = _value.ToString();
            _progressController.Health = _value;
        }
    }
}