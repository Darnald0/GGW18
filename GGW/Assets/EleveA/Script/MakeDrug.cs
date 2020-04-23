using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeDrug : MonoBehaviour
{
    public List<GameObject> ingredientInContainer = new List<GameObject>();

    public GameObject IngredientA;
    public GameObject IngredientB;
    public GameObject IngredientC;

    private int mix;

    public void AddIngredient(GameObject ingredientToAdd)
    {
        ingredientInContainer.Add(ingredientToAdd);
    }

    public void CheckContent()
    {
        if (ingredientInContainer.Count == 2)
        {
            Debug.Log(ingredientInContainer[0]);
            Debug.Log(ingredientInContainer[1]);
            if (ingredientInContainer[0] == IngredientA && ingredientInContainer[1] == IngredientB || ingredientInContainer[1] == IngredientA && ingredientInContainer[0] == IngredientB)
            {
                mix = 0;
                ingredientInContainer.Clear();
                for (int i = 0; i < 2; i++)
                {
                    GameObject ingredientToSuppr = transform.GetChild(0).gameObject;
                    ingredientToSuppr.SetActive(true);
                    ingredientToSuppr.transform.parent = GameObject.FindGameObjectWithTag("PropContainer").transform;
                }
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientA && ingredientInContainer[1] == IngredientC || ingredientInContainer[1] == IngredientA && ingredientInContainer[0] == IngredientC)
            {
                mix = 1;
                ingredientInContainer.Clear();
                for (int i = 0; i < 2; i++)
                {
                    GameObject ingredientToSuppr = transform.GetChild(0).gameObject;
                    ingredientToSuppr.SetActive(true);
                    ingredientToSuppr.transform.parent = GameObject.FindGameObjectWithTag("PropContainer").transform;
                }
                ChangeTrip();
            }
            if (ingredientInContainer[0] == IngredientB && ingredientInContainer[1] == IngredientC || ingredientInContainer[1] == IngredientB && ingredientInContainer[0] == IngredientC)
            {
                mix = 1;
                ingredientInContainer.Clear();
                for (int i = 0; i < 2; i++)
                {
                    GameObject ingredientToSuppr = transform.GetChild(0).gameObject;
                    ingredientToSuppr.SetActive(true);
                    ingredientToSuppr.transform.parent = GameObject.FindGameObjectWithTag("PropContainer").transform;
                }
                ChangeTrip();
            }
            if (ingredientInContainer[0] == ingredientInContainer[1])
            {
                Debug.Log("same ingredient");
                ingredientInContainer.Clear();
                for (int i = 0; i < 2; i++)
                {
                    GameObject ingredientToSuppr = transform.GetChild(0).gameObject;
                    ingredientToSuppr.SetActive(true);
                    ingredientToSuppr.transform.parent = GameObject.FindGameObjectWithTag("PropContainer").transform;
                }
                ChangeTrip();
            }
        }
    }

    public void ChangeTrip()
    {
        switch (mix)
        {
            case 0:
                Debug.Log("0a");
                break;
            case 1:
                Debug.Log("1a");
                break;
            case 2:
                Debug.Log("2a");
                break;
            case 3:
                Debug.Log("3a");
                break;
            case 4:
                Debug.Log("4a");
                break;
            case 5:
                Debug.Log("5a");
                break;
            default:
                Debug.Log("MakeDrugBug");
                break;
        }
    }
}
