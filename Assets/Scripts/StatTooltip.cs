using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatTooltip : MonoBehaviour
{
    [SerializeField] TMP_Text Item_Name_Text;
    [SerializeField] TMP_Text Item_Stats_Text;

    public void ShowTooltip(CollectableType item, int count)
    {
        Item_Name_Text.SetText(item.ToString());

        if (item == CollectableType.Chicken)
        {
            Item_Stats_Text.SetText("+" + (10 * count) + " Health");
            //Item_Stats_Text.SetText("+10 Health Per");
        }
        else if (item == CollectableType.Weapon)
        {
            Item_Stats_Text.SetText("+" + (5 * count) + " Attack");
            //Item_Stats_Text.SetText("+5 Attack Per");
        }
        else if (item == CollectableType.Wine)
        {
            Item_Stats_Text.SetText("+" + (3 * count) + " Speed");
            //Item_Stats_Text.SetText("+3 Speed Per");
        }
        else if (item == CollectableType.LuckyEgg)
        {
            Item_Stats_Text.SetText("+" + (2 * count) + "% Crit Chance");
            //Item_Stats_Text.SetText("+2% Crit Chance Per");
        }

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        Item_Name_Text.SetText("");
        Item_Stats_Text.SetText("");
        gameObject.SetActive(false);
    }
}
