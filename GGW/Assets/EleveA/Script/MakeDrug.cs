using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDrug : MonoBehaviour
{
    public static MakeDrug instance;
    public static List<GameObject> ingredientInContainer = new List<GameObject>();

    public GameObject IngredientA;
    public GameObject IngredientB;
    public GameObject IngredientC;
    public GameObject IngredientD;

    private int mix;
    private void Awake()
    {
        instance = this;
    }

    public void CheckContent()
    {
        Debug.Log("check");
        if(ingredientInContainer.Count == 2)
        {
            Debug.Log("=2");
            if (ingredientInContainer[0] == IngredientA && ingredientInContainer[1] == IngredientC)
            {
                mix = 1;
                ingredientInContainer.Clear();
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientA && ingredientInContainer[1] == IngredientD)
            {
                mix = 2;
                ingredientInContainer.Clear();
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientB && ingredientInContainer[1] == IngredientC)
            {
                mix = 3;
                ingredientInContainer.Clear();
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientB && ingredientInContainer[1] == IngredientD)
            {
                mix = 4;
                ingredientInContainer.Clear();
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientC && ingredientInContainer[1] == IngredientD)
            {
                mix = 5;
                ingredientInContainer.Clear();
                ChangeTrip();
            }
            if (ingredientInContainer[0] == ingredientInContainer[1]){
                Debug.Log("same ingredient");
                ingredientInContainer.Clear();
                ChangeTrip();
            }
        }
    }

    public void ChangeTrip()
    {
        switch(mix)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                break;
            case 5:
                Debug.Log("5");
                break;
        }
    }
}
