using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Stats
{
    public class HealthCounter : MonoBehaviour
    {
        [SerializeField] private Progress _progressController;
        [SerializeField] private MenuController _menuController;
    
        [SerializeField] private int _value;
        [SerializeField] private TMP_Text _uiText;
        public Image _shieldImage;
        [SerializeField] private bool _isShieldActive;

        private const int ValueMaxCount = 5;

        public static Action<GameObject> OnEnemyDestroyedByPlayer;

        private void OnEnable()
        {
            HealthPotion.OnHealthCollected += IncreaseValue;
            EnemyFight.OnEnemyFought += DecreaseValue;
            PlayerShieldBook.OnPlayerShieldActivated += ActivateShield;
        }

        private void OnDisable()
        {
            HealthPotion.OnHealthCollected -= IncreaseValue;
            EnemyFight.OnEnemyFought -= DecreaseValue;
            PlayerShieldBook.OnPlayerShieldActivated -= ActivateShield;
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

        private void DecreaseValue(GameObject enemy, int decrease)
        {
            if (_isShieldActive)
            {
                OnEnemyDestroyedByPlayer?.Invoke(enemy);
                _isShieldActive = false;
                UpdateValue();
                return;
            }
            
            _value -= decrease;

            if (_value <= 0)
            {
                _value = 0;
            }
            
            UpdateValue();
            _menuController.Dead();
        }

        private void ActivateShield()
        {
            _isShieldActive = true;
            UpdateValue();
        }

        private void UpdateValue()
        {
            _uiText.text = _value.ToString();
            _progressController.Health = _value;
            _shieldImage.gameObject.SetActive(_isShieldActive);
        }
    }
}