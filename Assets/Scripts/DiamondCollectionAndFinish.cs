using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class DiamondCollectionAndFinish : MonoBehaviour
{
    public int diamonds; // начальное количество очков
    public TMP_Text diamondsText; // ссылка на текстовый элемент для отображения очков

    void Start()
    {
        UpdateScoreText(); // обновляем текстовый элемент при старте игры
    }

      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            diamonds++;
            UpdateScoreText();
        }
        
        if (collision.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-2 ) //если пройденный уровень не последний
            {
                PlayerPrefs.SetInt("lvls", SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (PlayerPrefs.GetInt("lvlStars" + SceneManager.GetActiveScene().buildIndex) < diamonds) //записываем результат прохождения, если он лучше предыдущего
            {
                PlayerPrefs.SetInt("lvlStars" + SceneManager.GetActiveScene().buildIndex, diamonds);
            }
            GetComponentInChildren<ButtonController>().Finish(diamonds); //вызываем показ алмазов
        }
    }


    void UpdateScoreText()
    {
        diamondsText.text = diamonds.ToString(); // обновляем текстовый элемент с текущим количеством очков
    }
}
