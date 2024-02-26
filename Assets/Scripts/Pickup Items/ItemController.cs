using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item item;
    public bool isBeeingWatched;
    private UIController uic;
    private InventoryController inventoryController;
    // Start is called before the first frame update
    void Start()
    {
        uic = FindObjectOfType<UIController>();
        inventoryController = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeeingWatched)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (inventoryController.CheckForSlot(item.ID))
                {
                    uic.HidePickUpText();
                    PickUpItem();
                }
            }
        }
    }

    private void PickUpItem()
    {
        inventoryController.SaveItem(item);
        Destroy(this.gameObject);
    }

    public void TextForPickUp()
    {
        uic.ShowPickUpText(item.name);
    }
    public void HideTextForPickUp()
    {
        uic.HidePickUpText();
    }
}
