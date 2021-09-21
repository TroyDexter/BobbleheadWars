using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;

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
}
