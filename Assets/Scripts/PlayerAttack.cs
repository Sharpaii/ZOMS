using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Goal: A single, forward pistol shot spawned from the player's model, aimed in the direction of the mouse.
    //Needed: The player's position, the mouse's position, the projectile, it's speed, it colliding with an enemy or entity, 
    //   applying damage if it is an enemy, and despawning once it has collided.
    //Not needed here: Enemy dying logic, enemy getting knockbacked from the attack (extra),
    //  crit chance and crits affecting the damage applied by the projectile (consider)
    public GameObject player;
    public GameObject mousePos;
    public GameObject bullet;
    public float bulletVel;
    public float bulletDam;
}