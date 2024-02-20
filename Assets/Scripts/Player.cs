using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float defense;
    public float speed;
    public float critChance;
    PlayerMovement move;

    void Start()
    {
        // Set FPS to 60
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        move = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        move.Move();
    }
}

