
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Progress : MonoBehaviour
{
    public int Health;
    public int Coins;
    
    public bool[] lvlIsOpened = new bool[2]; //Должно соответствовать количеству уровней 
    public int[] lvlStars = new int[2]; //Должно соответствовать количеству уровней 
    public readonly int lvlQuantity = 2; //Должно соответствовать количеству уровней
    
    private static Progress Instance;
    
    private Dictionary<EnemyType, int> _enemySpellBooks = new Dictionary<EnemyType, int>
    {
        { EnemyType.Zombie , 1},
        { EnemyType.Warrior , 2},
        { EnemyType.Wizard , 3}
    };

    private void Awake()
    {
        
        lvlIsOpened[0] = true;
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        
    }

    public int GetEnemySpellBookCount(EnemyType enemyType)
    {
        return _enemySpellBooks[enemyType];
    }

    public void UpdateEnemyBookCount(EnemyType enemyType, int deltaCount)
    {
        _enemySpellBooks[enemyType] += deltaCount;

        if (_enemySpellBooks[enemyType] < 0)
        {
            _enemySpellBooks[enemyType] = 0;
        }
    }
}
