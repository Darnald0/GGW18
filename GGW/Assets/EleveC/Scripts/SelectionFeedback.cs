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
    public Material hoverMat;


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
            hoverMat.SetFloat("Boolean_9D67F661", 1.0f);
        }

        else if (!isHovered)
        {
            //transform.GetComponent<Renderer>().material = normalMaterial;
            hoverMat.SetFloat("Boolean_9D67F661", 0.0f);
        }
    }
}

