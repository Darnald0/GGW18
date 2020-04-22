using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    public bool lockMouse;

    [Header("Vision Prefs")]
    [SerializeField] private float rayDistance;
    [SerializeField] private string selectableTag = "Prop";
    [SerializeField] private RaycastHit lastRay;

    [Header("Interact Prefs")]
    [SerializeField] private Text interactText;
    [SerializeField] private GameObject interactHud;

    [HideInInspector] public bool visionLock = false;


    private void Start()
    {
        //--- Pour lock le curseur dans l'écran ---//
        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(interactHud != null)
        {
            interactHud.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
            Look();
            LineVision();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LineVision()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                if (lastRay.transform != null && lastRay.transform.GetComponent<SelectionFeedback>() != null)
                {
                    lastRay.transform.GetComponent<SelectionFeedback>().isHovered = false;
                }
                lastRay = hit;

                if (hit.transform.GetComponent<SelectionFeedback>() != null)
                {
                    hit.transform.GetComponent<SelectionFeedback>().isHovered = true;
                }

                //Debug.Log("Facing : " + hit.transform.name);

                ShowInteractHUD("Interact : " + hit.transform.name);

                //--- Pour prendre un objet ---//

                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerBody.GetComponent<Inventory>().PickUp(selection.gameObject);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                GameObject gotAnIngredientInHand = playerBody.transform.Find("Hand").transform.GetChild(0).gameObject;
                if (selection.CompareTag("IngredientContainer") && gotAnIngredientInHand.tag == selectableTag)
                {
                    hit.transform.GetComponent<MakeDrug>().AddIngredient(gotAnIngredientInHand);
                    //gotAnIngredientInHand.GetComponent<Collider>().transform.SetParent(hit.transform);
                    Inventory.instance.PutInContainer(gotAnIngredientInHand);
                    hit.transform.GetComponent<MakeDrug>().CheckContent();
                    
                }
            }

            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

        else
        {
            if (IsInteractHUDActive())
            {
                HideInteractHUD();
            }

            if(lastRay.transform != null)
            {
                lastRay.transform.GetComponent<SelectionFeedback>().isHovered = false;
            }
        }

        Debug.DrawLine(ray.origin, hit.point, Color.green);
    }

    private void ShowInteractHUD(string text)
    {
        if(interactHud != null)
        {
        interactHud.SetActive(true);
        interactText.text = text;
        }
    }

    private void HideInteractHUD()
    {
        interactHud.SetActive(false);
    }

    private bool IsInteractHUDActive()
    {
        return interactHud.activeSelf;
    }
}
