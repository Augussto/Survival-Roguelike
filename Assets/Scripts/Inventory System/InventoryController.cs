using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Transform dropItem;
    public Vector2[] items = new Vector2[8];
    [SerializeField] int availableSlot;

    private UIController uic;
    private Item[] collectedItemsList = new Item[8];

    // Start is called before the first frame update
    void Start()
    {
        uic = FindObjectOfType<UIController>();
    }

    public bool CheckForSlot(float ID)
    {
        bool isEmptySlot = false;
        for (int i = 0; i < 8; i++)
        {
            //Checks for the same item ID
            if (items[i].x == ID)
            {
                isEmptySlot = true;
                availableSlot = i;
                break;
            }
            //Checks for emptyslot
            if (items[i].x == 0)
            {
                if(isEmptySlot == false)
                {
                    isEmptySlot = true;
                    availableSlot = i;
                }
            }
        }
        return isEmptySlot;
    }

    public void SaveItem(Item item)
    {
        items[availableSlot] = new Vector2(item.ID, items[availableSlot].y + item.amount);
        collectedItemsList[availableSlot] = item;
        uic.ChangeItemIcon(item.icon ,availableSlot);
        uic.UpdateAmountText(availableSlot, items[availableSlot].y);
    }

    public void DropItem(int slotSelected)
    {
        if (items[slotSelected].x != 0)
        {
            items[slotSelected].y -= collectedItemsList[slotSelected].amount;
            Instantiate(collectedItemsList[slotSelected].gameObject,dropItem.position,Quaternion.identity);
            if (items[slotSelected].y == 0)
            {
                items[slotSelected].x = 0;
                collectedItemsList[slotSelected] = null;
                uic.ChangeItemIcon(null, slotSelected);
            }
        }
        uic.UpdateAmountText(slotSelected, items[slotSelected].y);
    }
}
