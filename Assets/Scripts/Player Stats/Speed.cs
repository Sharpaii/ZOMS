using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public int maxSpeed = 20;
    public int currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 5;
    }

    public void addSpeed(int amount)
    {
        currentSpeed += amount;

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }
}
