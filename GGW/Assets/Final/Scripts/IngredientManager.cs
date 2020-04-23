using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    static public int ingredientAvailable = 1;
    public GameObject ingredientA;
    public GameObject ingredientB;
    public GameObject ingredientC;

    void Awake()
    {
        switch (ingredientAvailable)
        {
            case 1:
                ingredientC.SetActive(false);
                 break;
            case 2:
                ingredientB.SetActive(false);
                break;
            case 3:
                ingredientA.SetActive(false);
                break;
            default:
                Debug.Log("Placement ingredient error");
                break;
        }
    }
}
