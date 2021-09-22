using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public Rigidbody head;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        //Creates an instance variable to store CharacterController
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a new Vector3 to store the movement direction
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Calls SimpleMove() and passes in moveDirection multiplied by moveSpeed.
        characterController.SimpleMove(moveDirection * moveSpeed);
    }

    void FixedUpdate()
    {
        //Calculate Movement direction
        Vector3 moveDirections = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Check if marine is standing still
        if (moveDirections == Vector3.zero)
        {
            //TODO
        }
        else
        {
            //if moving then add force amount
            head.AddForce(transform.right * 150, ForceMode.Acceleration);
        }
    }
}
