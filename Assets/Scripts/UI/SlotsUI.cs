using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SlotsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] StatTooltip tooltip;
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    public CollectableType item;
    public int count;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = "Lvl. " + slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

    protected virtual void OnValidate()
    {
        if (tooltip == null)
        {
            tooltip = FindObjectOfType<StatTooltip>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(item, count);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
