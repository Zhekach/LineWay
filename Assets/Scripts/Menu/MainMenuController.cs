using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class MainMenuController : MonoBehaviour
{
  public Button[] LvlButtons;
  public int lvlsUnlocked;
  public TMP_Text coinText;
  public void Start()
  {
    lvlsUnlocked = PlayerPrefs.GetInt("lvls", 1);

    for (int i = 0; i < LvlButtons.Length; i++)
    {
      LvlButtons[i].interactable = false;
    }
    
    for(int i = 0; i< lvlsUnlocked; i++)
    {
      LvlButtons[i].interactable = true;
      LvlButtons[i].GetComponent<lvlStars>().SetStars(PlayerPrefs.GetInt("lvlStars" + (i+1),0));
    }

    coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
  }
  
  public void Level1Load()
  {
    SceneManager.LoadScene(1);
  }

  public void Level2Load()
  {
    SceneManager.LoadScene(2);
  }

  public void ShopLoad()
  {
    SceneManager.LoadScene(3);
  }

  public void RefreshProgress()
  {
    PlayerPrefs.DeleteAll();
    SceneManager.LoadScene(0);
  }
}
