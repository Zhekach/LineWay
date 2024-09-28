using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Finish : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    public ScoreCounter ScoreCounter;
    public MenuController MenuController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-2 )
            {
                PlayerPrefs.SetInt("lvls", SceneManager.GetActiveScene().buildIndex + 1);
            }

            int scoreCount = ScoreCounter.ScoreCount;
            
            if (PlayerPrefs.GetInt("lvlStars" + SceneManager.GetActiveScene().buildIndex) < scoreCount)
            {
                PlayerPrefs.SetInt("lvlStars" + SceneManager.GetActiveScene().buildIndex, scoreCount);
            }
            
            MenuController.Finish(scoreCount);
        }
    }
}