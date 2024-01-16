using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CursorDisplay : MonoBehaviour
{
    private Camera cam;
    public InventoryObject inventory;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        UpdateDescription();

    }

    public void UpdateDescription()
    {
        // Child 0 is the name
        // Child 1 is the description
        if (inventory.container.Count > 0)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.container[inventory.container.Count - 1].item.name;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.container[inventory.container.Count - 1].item.description;
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "N/A";
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "There are no items in the inventory";
        }
    }

    public void RaycastToUI()
    {
        // Cast a ray, check if it collides with inventory item
        // If so, retrieve item data and assign display name and description texts
        // and render display

        // This casts rays only against colliders in layer 10 - inventory items
        LayerMask layerMask = LayerMask.GetMask("InventoryItem");
        ;

        RaycastHit hit;


        // This casts a ray from the main camera so this does not work with the UI
        Debug.DrawRay(cam.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction * 1000, Color.white);
        if (Physics.Raycast(cam.transform.position, cam.ScreenPointToRay(Input.mousePosition).direction * 1000, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Hit");
        }

        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Where(r => r.gameObject.layer == 10).Count() > 0) //10 being  InventoryItem layer
        {
            //Debug.Log(results[0].gameObject.name); //The UI Element
            Debug.Log(results[0].gameObject.transform.parent.name);
            //transform.position = results[0].gameObject.transform.parent.transform.position;

        }
    }
}
