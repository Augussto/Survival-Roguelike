using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerLook : MonoBehaviour
{
    [SerializeField] float maxDistance = 4;
    [SerializeField] GameObject lastHitGO;

    void FixedUpdate()
    {
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Resource
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Resource"))
        {
            
            hit.transform.GetComponent<ResourceController>().isBeeingWatched = true;
            lastHitGO = hit.collider.gameObject;

        }
        else // if raycast hits, it checks if it hit an object with the tag PickUpItem
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("PickUpItem"))
        {
            hit.transform.GetComponent<ItemController>().isBeeingWatched = true;
            hit.transform.GetComponent<ItemController>().TextForPickUp();
            lastHitGO = hit.collider.gameObject;
        }
        else
        {
            try
            {
                lastHitGO.GetComponent<ResourceController>().isBeeingWatched = false;
            }
            catch
            {
                Debug.Log("Buscando Objeto");
            }

            try
            {
                lastHitGO.GetComponent<ItemController>().isBeeingWatched = false;
                lastHitGO.GetComponent<ItemController>().HideTextForPickUp();
            }
            catch
            {
                Debug.Log("Buscando Objeto");
            }
        }

    }


}
