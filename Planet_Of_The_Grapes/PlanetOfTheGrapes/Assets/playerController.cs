using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour
{
    public float movementSpeed, rotationSpeed;
    private Rigidbody2D rb;
    private float maximumVelocity = 3;
   

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        // print(rb.velocity);
        print("x: "+CrossPlatformInputManager.GetAxis("Horizontal") + "y: "+ CrossPlatformInputManager.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Vector2 thrustForce = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * 2;

        Vector3 thrustDirection = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 4096);

        Vector2 test = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        transform.rotation = Quaternion.LookRotation(thrustDirection, Vector3.back);

       // transform.LookAt(test + thrustForce);

       // float xAxis = Input.GetAxis("Horizontal");
       // float yAxis = Input.GetAxis("Vertical");

        rb.AddForce(thrustForce);

        //transform.rotation = Quaternion.LookRotation()

        // Rotate(gameObject.transform, - thrustDirection);
        ClampMovement();
    }

    

    private void Rotate(Transform t, Vector2 thrustDirection)
    {
        //Vector3 direction = new Vector3(thrustDirection.x, thrustDirection.y, 0);
       // gameObject.transform.rotation = Quaternion.LookRotation(thrustDirection);
    }

    private void ClampMovement()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maximumVelocity, maximumVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maximumVelocity, maximumVelocity);

        rb.velocity = new Vector2(x, y);
    }
}
