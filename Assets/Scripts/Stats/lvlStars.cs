using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlStars : MonoBehaviour
{
    //[SerializeField] GameObject [] stars = new GameObject [3];
    [SerializeField] UnityEngine.UI.Image [] stars12 = new UnityEngine.UI.Image [3];
    [SerializeField] Sprite newSprite;
    public void SetStars(int starsQuantity)
    {
        if (starsQuantity > 0)
        {
            for (int i = 0; i < starsQuantity; i++)
            {
                //stars[i].SetActive(true);
                stars12[i].overrideSprite = newSprite;
            }
        }
    }

}
