using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public float cooldownTime;
    public AudioSource audioSource;
    public bool canSound = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LaunchSound();
    }

    void LaunchSound()
    {
        if (canSound)
        {
            audioSource.Play();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canSound = false;
        yield return new WaitForSeconds(cooldownTime);
        canSound = true;

    }
}
