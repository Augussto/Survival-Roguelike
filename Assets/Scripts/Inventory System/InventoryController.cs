using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    
    public Vector2[] items = new Vector2[8];
    [SerializeField] int availableSlot;

    private UIController uic;

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

    public void SaveItem(float ID, Sprite icon, float amount)
    {
        items[availableSlot] = new Vector2(ID, items[availableSlot].y + amount);
        uic.ChangeItemIcon(icon,availableSlot);
    }
}
