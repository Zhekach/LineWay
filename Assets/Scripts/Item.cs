using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Shop scriptShop;
    
    public string nameItem;
    public int priceItem;
    public bool isBuy;
    public bool isEquipped;
    public int skinNumItem;
    public Image coinIcon;

    public TMP_Text textItem;

    public void BuyItem()
    {
        if (isBuy == false)
        {
            scriptShop.nameItem = nameItem;
            scriptShop.priceItem = priceItem;
            scriptShop.BuyItem();
        }
    }

    public void EquipItem()
    {
        if (isEquipped == false)
        {
            scriptShop.skinNumItem = skinNumItem;
            scriptShop.EquipItem();
        }
    } 
}
