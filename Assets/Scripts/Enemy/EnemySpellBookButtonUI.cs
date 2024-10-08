using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemySpellBookButtonUI : MonoBehaviour
{
    [SerializeField] private LayerMask _spellBookMask;
    [SerializeField] private EnemySpellBook _sprite;

    public bool IsPressed;

    //public MouseDownEvent();

    public void Clicked()
    {
        IsPressed = true;
        Debug.Log("Touched");
    }
    
    public void OnMouseDown()
    {
        IsPressed = true;
        Debug.Log("OnMouseDown");
    }

    private void Update()
    {
        if (IsPressed && _sprite != null)
        {
            Vector3 spritePosition =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            spritePosition.z = 0;
            _sprite.transform.position  = spritePosition;
            
            if (Input.GetMouseButtonUp(0))
            {
                IsPressed = false;
                _sprite.IsActivated = true;
            }
        }
    }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector3 mousePosition =
    //             Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //         RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100f, _spellBookMask);
    //         if (hit)
    //         {
    //             IsPressed = true;
    //         }
    //     }
    //
    //     if (IsPressed)
    //     {
    //         Vector3 spritePosition =
    //             Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //         spritePosition.z = 0;
    //         _sprite.transform.position = spritePosition;
    //     }
    //
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         IsPressed = false;
    //     }
    // }
}