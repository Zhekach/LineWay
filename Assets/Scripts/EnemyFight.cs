using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] GameObject Respawn;
    public int health = 2;  // start amount HP
    public TMP_Text healthText;     // link for HP text in UI

    public int coins = 0;   // start amount coins
    public TMP_Text coinsText;  // link for coins text in UI

    [SerializeField] private int enemyHealth1;
    [SerializeField] private int enemyMoney1;
    [SerializeField] private int enemyHealth2;
    [SerializeField] private int enemyMoney2;
    [SerializeField] private int enemyHealth3;
    [SerializeField] private int enemyMoney3;
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins",0);
        UpdateCoinsText();
        UpdateHealthText(); // обновляем текстовый элемент при старте игры
    }

      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health = health - enemyHealth1;
            coins = coins + enemyMoney1;
            Destroy(collision.gameObject);
            UpdateHealthText();
            UpdateCoinsText();
        }
        
        if (collision.CompareTag("Enemy2"))
        {
            health = health - enemyHealth2;
            coins = coins + enemyMoney2;
            Destroy(collision.gameObject);
            UpdateHealthText();
            UpdateCoinsText();
        }
        
        if (collision.CompareTag("Enemy3"))
        {
            health = health - enemyHealth3;
            coins = coins + enemyMoney3;
            Destroy(collision.gameObject);
            UpdateHealthText();
            UpdateCoinsText();
        }

        if (health <= 0)
        {
            GetComponentInParent<PlayerMovement>().StopMove();
            GetComponentInChildren<ButtonController>().Dead();
            gameObject.transform.position = Respawn.transform.position;
        }
        if (collision.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            health++;
            UpdateHealthText();
        }
    }


    void UpdateHealthText()
    {
        healthText.text = health.ToString(); // обновляем текстовый элемент с текущим количеством очков
    }
    void UpdateCoinsText()
    {
        coinsText.text = coins.ToString(); // обновляем текстовый элемент с текущим количеством очков
    }

    public void SaveToProgress()
    {
        PlayerPrefs.SetInt("coins", coins);
    }
}
