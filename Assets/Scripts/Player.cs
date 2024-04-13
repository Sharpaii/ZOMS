using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float defense; // Will be implemented
    public float critChance; // Will be implemented

    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }
}

