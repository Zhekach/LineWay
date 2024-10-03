using System;
using TMPro;
using UnityEngine;

namespace Stats
{
    public class HealthCounter : MonoBehaviour
    {
        public TMP_Text HealthText;

        [SerializeField] private int _healthCount = 3;
        [SerializeField] private int _healthMaxCount = 5;

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
            var resultHealth = _healthCount + healthDelta;
            if (resultHealth > 0 && 
                resultHealth <= _healthMaxCount)
            {
                _healthCount = resultHealth;
            }
            else if (resultHealth > _healthMaxCount)
            {
                _healthCount = _healthMaxCount;
            }
            else if (resultHealth <= 0)
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