using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam; // Camera that the mouse position will track from
    private Vector3 mousePos; // Mouse position
    public GameObject bullet; // The bullet projectile
    public Transform bulletTransform; // The origin point of a bullet
    public bool canFire;
    private float timer; // canFire and timer are used to determine how often bullets can be shot
    public float timeBetweenFiring; 
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position relative to where the mainCam is
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        // Create a rotation vector in degrees
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        // Check to see if canFire is false. If so, increase the timer.
        if(!canFire){
            timer += Time.deltaTime;
            // If timer is greater than whatever timeBetweenFiring is, then set canFire to true and reset the timer.
            if(timer > timeBetweenFiring){
                canFire = true;
                timer = 0;
            }
        }
        // Check to see if a left click has occurred, and if we canFire. If so, set canFire to false and instantiate a bullet.
        if(Input.GetMouseButton(0) && canFire){
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
