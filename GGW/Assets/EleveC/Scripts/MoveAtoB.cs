using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtoB : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2;

    [SerializeField] private float beforeDestroy;

    public bool isActive;

    private bool alreadyLaunched;

    public bool soundLaunched = false;
    private Material monsterMat;



    // Start is called before the first frame update
    void Start()
    {
        monsterMat = GetComponentInChildren<Renderer>().material;
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
        Move();
        CheckPos();
        }

    }

    void Move()
    {
        Vector3 dir = (pointB.position - pointA.position).normalized;

        monsterMat.SetFloat("isInactive", 1.0f);

        transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);

        if(GetComponent<Sounds>() != null && !soundLaunched)
        {
            GetComponent<Sounds>().canSound = true;
            soundLaunched = true;
        }

        if (!alreadyLaunched)
        {
            StartCoroutine(AutoDestruct());
            alreadyLaunched = true;
        }

    }

    void CheckPos()
    {
        if(transform.position == pointB.position)
        {
            Debug.Log(transform.name + " has arrived");
        }
    }

    IEnumerator Cooldown()
    {
        monsterMat.SetFloat("isInactive", 1.0f);
        yield return new WaitForSeconds(4);
        monsterMat.SetFloat("isInactive", 0.0f);
    }

    IEnumerator AutoDestruct()
    {
        yield return new WaitForSeconds(beforeDestroy);
        Destroy(this.gameObject);
    }
}
