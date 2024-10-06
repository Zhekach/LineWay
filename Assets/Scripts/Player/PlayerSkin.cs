using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public Sprite[] skins;

    void Start()
    {
        _spriteRenderer.sprite = skins[PlayerPrefs.GetInt("skinNum", 0)];
    }
}
