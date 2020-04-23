using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTrigger : MonoBehaviour
{
    enum EventType
    {
        Anim,
        Sound,
        Exit,
    }

    [SerializeField] private EventType eventType;

    [Header("Anim Setup")]
    [SerializeField] private GameObject toLaunch;

    [Header("Exit Setup")]
    [SerializeField] private string nameScene;
    [SerializeField] private float timeBeforeSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            LaunchEvent(collision.gameObject);
        }
    }

    private void LaunchEvent(GameObject collision)
    {
        Debug.Log("Launching Event");

        if(eventType == EventType.Anim)
        {
            //--- Lancer une animation ---//
            toLaunch.GetComponent<MoveAtoB>().isActive = true;
        }

        if(eventType == EventType.Exit)
        {
            Debug.Log("Exiting to : " + nameScene);
            StartCoroutine(SwitchScene(collision));
        }
    }

    IEnumerator SwitchScene(GameObject collision)
    {
        collision.GetComponentInChildren<Drug>().needOpen = false;
        collision.GetComponentInChildren<Drug>().needClose = true;
        yield return new WaitForSeconds(timeBeforeSwitch);
        SceneManager.LoadScene(nameScene);
    }

}
