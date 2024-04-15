using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    public GameObject loseLevelPanel;
    // Start is called before the first frame update
    void Start()
    {
        loseLevelPanel.SetActive(false);
    }
}
