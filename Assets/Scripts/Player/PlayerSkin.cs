using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public Sprite[] skins;

    public GameObject player;
    void Start()
    {
        player.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("skinNum", 0)];
    }
}
