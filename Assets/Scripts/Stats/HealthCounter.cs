using TMPro;
using UnityEngine;

namespace Stats
{
    public class HealthCounter : MonoBehaviour
    {
        [SerializeField] private int _healthCount = 3;
        public TMP_Text HealthText;
    
        public int HealthCount => _healthCount;

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
    
        private void UpdateText()
        {
            HealthText.text = _healthCount.ToString();
        }

        private void UpdateHealthCount(int healthDelta)
        {
            _healthCount += healthDelta;
            UpdateText();
        }
    }
}