using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionFeedback : MonoBehaviour
{
    public bool isHovered;

    public Vector3 size;

    [Header("Materials Prefs")]
    public Material normalMaterial;
    [SerializeField] private Material selectMaterial;


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
            transform.GetComponent<Renderer>().material = selectMaterial;
        }

        else if (!isHovered)
        {
            transform.GetComponent<Renderer>().material = normalMaterial;
        }
    }
}

