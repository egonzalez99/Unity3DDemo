using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactRadius = 3f;
    public UnityEvent onInteract;
    public Canvas interactCanvas;
    public Text interactText;
    public bool canInteract;
    public string prompt = "Press 'E' to sleep";

    protected virtual void Start()
    {
        // You can add any initialization code here
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteraction();
        }
    }

    private void ShowInteractionPrompt()
    {
        interactCanvas.enabled = true;
        interactText.text = prompt;
    }

    private void HideInteractionPrompt()
    {
        interactCanvas.enabled = false;
    }

    void CheckForInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Interact(collider.gameObject);
            }
        }

        if (Physics.Raycast(ray, out hit, interactRadius))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                ShowInteractionPrompt();
                canInteract = true;
            }
            else
            {
                HideInteractionPrompt();
                canInteract = false;
            }
        }
        else
        {
            HideInteractionPrompt();
            canInteract = false;
        }
    }

    protected virtual void Interact(GameObject player)
    {
        // This method can be overridden by specific interactable objects
        Debug.Log("Interacting with " + gameObject.name);
        onInteract.Invoke();
    }
}
