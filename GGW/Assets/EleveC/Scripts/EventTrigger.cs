using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    enum EventType
    {
        Anim,
        Sound,
    }

    [SerializeField] private EventType eventType;

    [Header("Anim Setup")]
    [SerializeField] private GameObject toLaunch;


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
            LaunchEvent();
        }
    }

    private void LaunchEvent()
    {
        Debug.Log("Launching Event");

        if(eventType == EventType.Anim)
        {
            //--- Lancer une animation ---//
            toLaunch.GetComponent<MoveAtoB>().isActive = true;
        }
    }

}
