using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightclign : MonoBehaviour
{
    public GameObject light;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(clignotte());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator clignotte()
    {
        light.SetActive(false);
        yield return new WaitForSeconds(2);
        light.SetActive(true);
        StartCoroutine(clignotte());
    }
}
