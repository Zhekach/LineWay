using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject BCont;
    [SerializeField] private GameObject BMenu;
    [SerializeField] private GameObject BResp;
    [SerializeField] private GameObject BNext;
    [SerializeField] private GameObject[] Diamonds = new GameObject[3];
    [SerializeField] private EnemyFight enemyFight;
    
    private void Start()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BResp.SetActive(false);
        BNext.SetActive(false);
        Diamonds[0].SetActive(false);
        Diamonds[1].SetActive(false);
        Diamonds[2].SetActive(false);
    }

    public void Pause()
    {
        BCont.SetActive(true);
        BMenu.SetActive(true);
        BResp.SetActive(false);
        BNext.SetActive(false);
        Time.timeScale = 0;
    }

    public void Respawn()
    {
        BMenu.SetActive(false);
        BResp.SetActive(false);
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

    public void Dead()
    {
        BResp.SetActive(true);
        BMenu.SetActive(true);
        BNext.SetActive(false);
        Time.timeScale = 0;
    }

    public void Finish(int score)
    {
        GetComponentInParent<PlayerMovement>().StopMove();
        BResp.SetActive(true);
        BMenu.SetActive(true);
        BNext.SetActive(true);
        enemyFight.SaveToProgress();
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
        BResp.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
