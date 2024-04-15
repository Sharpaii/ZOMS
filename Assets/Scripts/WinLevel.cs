using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    public GameObject nextLevelPanel;

    void Start()
    {
        nextLevelPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToggleScreen();
    }

    public void ToggleScreen()
    {
        if (!nextLevelPanel.activeSelf)
        {
            nextLevelPanel.SetActive(true);
            Time.timeScale = 0;
            // Bug where opening inventory and closing it allows you to move when you have the win screen open
        }
    }
}
