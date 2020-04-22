using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    // [SerializeField] public List<GameObject> playerInventory;
    public static Inventory instance;

    [SerializeField] public GameObject playerHand;
    [SerializeField] public GameObject dropZone;

    public bool pickupCooldown;

    [Header("Inventory Prefs")]
    public GameObject inHand;

    private float handScale;

    [SerializeField] private GameObject container;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pickupCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshInventory();
        // SwapItem();
    }

    public void PickUp(GameObject toPick)
    {
        toPick.GetComponentInChildren<Collider>().enabled = false;

        if (inHand == null)
        {
            handScale = toPick.transform.lossyScale.y;

            inHand = toPick;
            inHand.transform.rotation = Quaternion.identity;
            StartCoroutine(PickupCooldown());
        }

        if (inHand != null)
        {
            Drop(inHand);

            inHand = toPick;

            handScale = toPick.transform.lossyScale.y;
          
            inHand.transform.rotation = Quaternion.identity;
            inHand.SetActive(true);

            StartCoroutine(PickupCooldown());
        }
    }

    public void Drop(GameObject toDrop)
    {
        inHand = null;

        toDrop.transform.parent = GameObject.FindGameObjectWithTag("PropContainer").transform;
        toDrop.transform.position = dropZone.transform.position;
        toDrop.GetComponent<Rigidbody>().velocity = Vector3.zero;
        toDrop.GetComponentInChildren<Collider>().enabled = true;
    }

    public void PutInContainer(GameObject toAdd)
    {
        inHand = null;

        toAdd.transform.parent = container.transform;
        toAdd.SetActive(false);
    }

    public void DestroyHand()
    {
        Destroy(inHand);
    }

    //--- Gère l'affichage dans l'inventaire et dans la main du joueur ---//
    void RefreshInventory()
    {
        if (inHand != null)
        {
            inHand.transform.position = playerHand.transform.position;
            inHand.transform.parent = playerHand.transform;
            //inHand.transform.localScale = inHand.GetComponent<SelectionFeedback>().size;

            inHand.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                Drop(inHand);
            }
        }
    }

    public IEnumerator PickupCooldown()
    {
        pickupCooldown = true;
        yield return new WaitForSeconds(1.0f);
        pickupCooldown = false;
    }

    public void ScaleInHand()
    {
        if (inHand != null)
        {
            inHand.transform.localScale = new Vector3(inHand.transform.localScale.x, inHand.transform.localScale.y / (inHand.transform.lossyScale.y / handScale), inHand.transform.localScale.z);
        }
    }
}
