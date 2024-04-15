using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChance : MonoBehaviour
{
    public int maxCritChance = 100;
    public int currentCritChance;
    // Start is called before the first frame update
    void Start()
    {
        currentCritChance = 2;
    }

    public void addCritChance(int amount)
    {
        currentCritChance += amount;

        if (currentCritChance > maxCritChance)
        {
            currentCritChance = maxCritChance;
        }
    }
}
