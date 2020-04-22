using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtoB : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2;

    public bool isActive;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
        Move();
        }

        CheckPos();
    }

    void Move()
    {
        Vector3 dir = (pointA.position - pointB.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    void CheckPos()
    {
        if(transform.position == pointA.position)
        {
            Debug.Log(transform.name + " has arrived");
        }
    }
}
