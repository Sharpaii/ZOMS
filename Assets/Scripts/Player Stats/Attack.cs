using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int maxAttack = 100;
    public int currentAttack;

    // Start is called before the first frame update
    void Start()
    {
        currentAttack = 10;
    }

    public void addAttack(int amount)
    {
        currentAttack += amount;

        if (currentAttack > maxAttack)
        {
            currentAttack = maxAttack;
        }
    }
}
