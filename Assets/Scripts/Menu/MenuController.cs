using System;
using Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject BCont;
    [SerializeField] private GameObject BMenu;
    [SerializeField] private GameObject BRespawn;
    [SerializeField] private GameObject BNext;
    [SerializeField] private GameObject[] Diamonds = new GameObject[3];
    
    private void Start()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BRespawn.SetActive(false);
        BNext.SetActive(false);
        Diamonds[0].SetActive(false);
        Diamonds[1].SetActive(false);
        Diamonds[2].SetActive(false);
    }

    public void Pause()
    {
        BCont.SetActive(true);
        BMenu.SetActive(true);
        BRespawn.SetActive(false);
        BNext.SetActive(false);
        Time.timeScale = 0;
    }

    public void Respawn()
    {
        BMenu.SetActive(false);
        BRespawn.SetActive(false);
        BNext.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Time.timeScale = 1;
    }

    public void Finish(int score)
    {
        GetComponentInParent<PlayerMovement>().StopMove();
        BRespawn.SetActive(true);
        BMenu.SetActive(true);
        BNext.SetActive(true);
        //TODO Fix refaxtor
        //enemyFight.SaveToProgress();
        for(int i = 0; i < score; i++)
        {
         Diamonds[i].SetActive(true);   
        }
        Time.timeScale = 0;
    }
    
    public void Next()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    
    public void Menu()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BRespawn.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void Dead()
    {
        BRespawn.SetActive(true);
        BMenu.SetActive(true);
        BNext.SetActive(false);
        Time.timeScale = 0;
    }
}
