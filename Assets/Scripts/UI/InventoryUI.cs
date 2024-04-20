using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] StatTooltip tooltip;
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotsUI> slots = new List<SlotsUI>();
    public TMP_Text statBox;
    public GameObject child;
    public GameObject tooltipPanel;

    void Start()
    {
        inventoryPanel.SetActive(false);
        tooltipPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0;
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
            tooltip.HideTooltip();
            Time.timeScale = 1;
        }
    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                    slots[i].item = player.inventory.slots[i].type;
                    slots[i].count = player.inventory.slots[i].count;
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }

        child = this.gameObject.transform.GetChild(0).GetChild(3).gameObject;
        statBox = child.gameObject.GetComponent<TMP_Text>();
        statBox.SetText("Health: " + player.GetComponent<Health>().currentHealth + "/" + player.GetComponent<Health>().maxHealth);

        child = this.gameObject.transform.GetChild(0).GetChild(4).gameObject;
        statBox = child.gameObject.GetComponent<TMP_Text>();
        statBox.SetText("Attack: " + player.GetComponent<Attack>().currentAttack);

        child = this.gameObject.transform.GetChild(0).GetChild(5).gameObject;
        statBox = child.gameObject.GetComponent<TMP_Text>();
        statBox.SetText("Speed: " + player.GetComponent<Speed>().currentSpeed);

        child = this.gameObject.transform.GetChild(0).GetChild(6).gameObject;
        statBox = child.gameObject.GetComponent<TMP_Text>();
        statBox.SetText("Crit Chance: " + player.GetComponent<CritChance>().currentCritChance + "%");
    }
}
