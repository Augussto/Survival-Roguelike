using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlotSelection : MonoBehaviour
{
    [SerializeField] private Image [] slotsInventory;
    public int slotsSelected;

    private InventoryController inventoryController;
    // Start is called before the first frame update
    void Start()
    {
        inventoryController = GetComponent<InventoryController>();
        slotsInventory[0].color = Color.yellow;
        slotsSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0f)
        {
            slotsInventory[slotsSelected].color = Color.white;
            slotsSelected++;
            if (slotsSelected > slotsInventory.Length -1)
            {
                slotsSelected = 0;
            }
            slotsInventory[slotsSelected].color = Color.yellow;
        }
        else if(Input.mouseScrollDelta.y < 0f)
        {
            slotsInventory[slotsSelected].color = Color.white;
            slotsSelected--;
            if (slotsSelected < 0)
            {
                slotsSelected = slotsInventory.Length -1;
            }
            slotsInventory[slotsSelected].color = Color.yellow;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            inventoryController.DropItem(slotsSelected);
        }
    }
}
