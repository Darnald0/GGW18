using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject target;
    public GameObject camera;

    public GameObject ticTac;
    public GameObject fallBody;

    public AudioSource endingSpeach;

    public bool isEnding;
    public bool launchEnding;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnding)
        {
            camera.transform.position = target.transform.position;
            camera.transform.rotation = target.transform.rotation;
        }

        if (isEnding && !launchEnding)
        {
            launchEnding = true;

            fallBody.SetActive(true);
            camera.transform.parent = fallBody.transform;
            ticTac.SetActive(false);

            StartCoroutine(WaitForEnd());
        }
    }

    IEnumerator WaitForEnd()
    {
        endingSpeach.Play();
        yield return new WaitForSeconds(2);
        GetComponentInChildren<Drug>().Piqure();
        yield return new WaitForSeconds(14.5f);
        SceneManager.LoadScene("Ending");
    }
}
