using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    private Shop.PlayerShopping playerShopping = new PlayerShopping();
    [HideInInspector] public string nameItem;
    [HideInInspector] public int priceItem;
    [HideInInspector] public int skinNumItem;
    public GameObject[] allSkins;
    public TMP_Text coinText;
    
    public class PlayerShopping
    {
        public List<string> skins = new List<string>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveShopping"))
        {
            LoadShopping();
        }
        else
        {
            SaveShopping();    
        }
    }

    private void SaveShopping()
    {
        PlayerPrefs.SetString("SaveShopping", JsonUtility.ToJson(playerShopping));
        RefreshCoins();
    }

    private void LoadShopping()
    {
        playerShopping = JsonUtility.FromJson<PlayerShopping>(PlayerPrefs.GetString("SaveShopping"));

        for (int i = 0; i < playerShopping.skins.Count; i++)
        {
            for (int j = 0; j < allSkins.Length; j++)
            {
                if (allSkins[j].GetComponent<Item>().nameItem == playerShopping.skins[i])
                {
                    allSkins[j].GetComponent<Item>().textItem.text = "куплен";
                    allSkins[j].GetComponent<Item>().coinIcon.enabled = false;
                    allSkins[j].GetComponent<Item>().isBuy = true;
                    allSkins[j].GetComponent<Item>().isEquipped = false;
                }
            }
        }

        if (PlayerPrefs.GetInt("skinNum") > 0)
        {
            allSkins[PlayerPrefs.GetInt("skinNum") - 1].GetComponent<Item>().textItem.text = "надет";    
        }
        RefreshCoins();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BuyItem()
    {
        if (PlayerPrefs.GetInt("coins") >= priceItem)
        {
            playerShopping.skins.Add(nameItem);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - priceItem);
            
            SaveShopping();
            LoadShopping();
        }
    }

    public void EquipItem()
    {
        PlayerPrefs.SetInt("skinNum", skinNumItem);
        SaveShopping();
        LoadShopping();
    }

    public void RefreshCoins()
    {
        coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }
}
