using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] float amount;
    public float ID;
    public Sprite icon;
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
                if (inventoryController.CheckForSlot(ID))
                {
                    uic.HidePickUpText();
                    PickUpItem();
                }
            }
        }
    }

    private void PickUpItem()
    {
        inventoryController.SaveItem(ID, icon, amount);
        Destroy(this.gameObject);
    }

    public void TextForPickUp()
    {
        uic.ShowPickUpText(itemName);
    }
    public void HideTextForPickUp()
    {
        uic.HidePickUpText();
    }
}
