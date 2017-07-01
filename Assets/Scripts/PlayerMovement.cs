using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject sphereCentre;
    public GameObject groundCheckObject;

    public float speed = 0.5f;
    public float jumpPower = 5;
    public float gravityMultiplier = 1;

    private float distance = 0.5f;
    private float horiz;
    private float vert;
    private Rigidbody rb;
    private Vector3 v;
    private bool grounded = true;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        grounded = Physics.Raycast(groundCheckObject.transform.position, -gameObject.transform.forward, distance);
        transform.LookAt(sphereCentre.transform.position, transform.up);

        Physics.gravity = -(sphereCentre.transform.position - gameObject.transform.position) * gravityMultiplier;

        horiz = Input.GetAxis("Horizontal") * speed;
        vert = Input.GetAxis("Vertical") * speed;
        v = new Vector3(horiz, -vert, 0);
        transform.Translate(v);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(-(Physics.gravity) * jumpPower);
        }

      //  transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
       // rb.velocity = new Vector3(horiz, 0, vert);
	}
}
