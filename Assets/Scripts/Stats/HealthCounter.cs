using System;
using TMPro;
using UnityEngine;

namespace Stats
{
    public class HealthCounter : MonoBehaviour
    {
        public TMP_Text HealthText;
        
        [SerializeField] private int _healthCount = 3;
    
        public int HealthCount => _healthCount;

        public static Action OnPlayerHealthDecreased;

        private void OnEnable()
        {
            HealthPotion.OnHealthCollected += UpdateHealthCount;
            EnemyFight.OnEnemyFought += UpdateHealthCount;
        }

        private void OnDisable()
        {
            HealthPotion.OnHealthCollected -= UpdateHealthCount;
            EnemyFight.OnEnemyFought -= UpdateHealthCount;
        }

        void Start()
        {
            UpdateText();
        }

        private void UpdateHealthCount(int healthDelta)
        {
            if (_healthCount + healthDelta > 0)
            {
                _healthCount += healthDelta;
            }
            else
            {
                _healthCount = 0;
            }
            
            UpdateText();

            if (healthDelta < 0)
            {
                OnPlayerHealthDecreased?.Invoke();
            }
        }
            
        private void UpdateText()
        {
            HealthText.text = _healthCount.ToString();
        }
    }
}