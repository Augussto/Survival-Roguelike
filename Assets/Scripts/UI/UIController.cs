using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    [SerializeField] private Image[] itemIcons;
    [SerializeField] private Text[] amountText;

    public void ShowPickUpText(string itemName)
    {
        pickUpText.text = "PICK UP " + itemName;
        pickUpText.gameObject.SetActive(true);
    }

    public void HidePickUpText()
    {
        pickUpText.gameObject.SetActive(false);
    }

    public void ChangeItemIcon(Sprite newIcon, int pos)
    {
        itemIcons[pos].sprite = newIcon;
    }

    public void UpdateAmountText(int pos, float amount)
    {
        amountText[pos].text = amount.ToString();
    }
}
