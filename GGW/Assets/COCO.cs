using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COCO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndingScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndingScreen()
    {
        yield return new WaitForSeconds(27);
        SceneManager.LoadScene("Menu");
    }
}
