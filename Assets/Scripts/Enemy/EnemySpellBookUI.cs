using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpellBookUI : MonoBehaviour
{

    [SerializeField] private string _enemyTag = "Enemy";
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private Button _button;

    public bool IsPressed;
    public bool IsActivated;
    
    public void ButtonClicked()
    {
        IsPressed = true;
        Debug.Log("Touched");
    }
    
    private void Update()
    {
        if (IsPressed )
        {
            Vector3 spritePosition =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            spritePosition.z = 0;
            Debug.Log(spritePosition.x);
            transform.position  = spritePosition;
            
            if (Input.GetMouseButtonUp(0))
            {
                IsPressed = false;
                IsActivated = true;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_enemyTag) && IsActivated)
        {
            EnemyReward enemyReward = collision.gameObject.GetComponent<EnemyReward>();
            enemyReward.HandleSpell(_enemyType);
            Destroy(gameObject);
        }
    }
}