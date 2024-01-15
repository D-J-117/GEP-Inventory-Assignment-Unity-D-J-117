using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CursorDisplay : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
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
            

        }


    }

}
