using UnityEngine;
using System.Collections;

public class TestPlayerMove : MonoBehaviour {

    CharacterController con;
    public float speed = 6;
    public float jumpSpeed = 8;
    public float gravity = 20;
    Vector3 move = Vector3.zero;    
    public float rotationspeed = 2;

    // Use this for initialization
    void Start () {
        con = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (con.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= speed;
            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }
        }
        move.y -= gravity * Time.deltaTime;
            
        con.Move(move * Time.deltaTime);        
    }
}
