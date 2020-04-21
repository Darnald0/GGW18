using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionFeedback : MonoBehaviour
{
    public bool isHovered;

    public Vector3 size;

    //[Header("Materials Prefs")]
    //public Material normalMaterial;
    //[SerializeField] private Material selectMaterial;


    private void Start()
    {
        size = transform.localScale;
    }

    void Update()
    {
        Hover();
    }

    void Hover()
    {
        if (isHovered)
        {
            //transform.GetComponent<Renderer>().material = selectMaterial;
            Debug.Log("HOVER");
            GetComponent<Renderer>().material.SetFloat("_Outline", 0.02f);
        }

        else if (!isHovered)
        {
            //transform.GetComponent<Renderer>().material = normalMaterial;
            GetComponent<Renderer>().material.SetFloat("_Outline", 0);
        }
    }
}

