using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Get the mouse position relative to where the mainCam is
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        // Assign rigid body
        rb = GetComponent<Rigidbody2D>();
        // Set mouse position
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos -transform.position; // Determines the direction the bullet will go in
        Vector3 rotation = transform.position - mousePos; // Determines the direction the bullet sprite will point
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; // Determines the velocity of the bullet.
                                        // Normalized sets the magnitude to one, so the bullet speed won't change.
        // Set the rotation of the bullet's sprite
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90); // Adding 90 makes it point in the direction we want
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys bullet after 4 seconds of existing
        timer += Time.deltaTime;
        if(timer > 4){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
