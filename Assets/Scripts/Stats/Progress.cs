
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int coins;
    public readonly int lvlQuantity = 2; //Должно соответствовать количеству уровней
    public bool[] lvlIsOpened = new bool[2]; //Должно соответствовать количеству уровней 
    public int[] lvlStars = new int[2]; //Должно соответствовать количеству уровней 
    
    [SerializeField] private Dictionary<EnemyType, int> EnemySpellBooks;
    
    public static Progress Instance;

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
        return EnemySpellBooks[enemyType];
    }

    public void UpdateEnemyBookCount(EnemyType enemyType, int deltaCount)
    {
        EnemySpellBooks[enemyType] += deltaCount;

        if (EnemySpellBooks[enemyType] < 0)
        {
            EnemySpellBooks[enemyType] = 0;
        }
    }
}
