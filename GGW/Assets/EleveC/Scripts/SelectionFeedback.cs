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
    private Material hoverMat;


    private void Start()
    {
        size = transform.localScale;
        hoverMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Hover();
    }

    void Hover()
    {
        if (isHovered)
        {
            //Debug.Log("HOVER");
            hoverMat.SetFloat("isHoverBool", 1.0f);
        }

        else if (!isHovered)
        {
            hoverMat.SetFloat("isHoverBool", 0.0f);
        }
    }
}

