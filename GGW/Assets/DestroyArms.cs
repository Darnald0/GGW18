using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArms : MonoBehaviour
{
    public GameObject Arms;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(); 
    }

    void Destroy()
    {
        StartCoroutine(DestroyCD());
    }

    void Spawn()
    {
        Arms.SetActive(true);
    }

    IEnumerator DestroyCD()
    {
        yield return new WaitForSeconds(10);
        Arms.SetActive(false);
    }
}
