using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public Rigidbody head;
    public LayerMask layerMask;

    private CharacterController characterController;
    private Vector3 currentLookTarget = Vector3.zero;

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

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;

                //Get target position
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                //Calculate the quaternion for where the marine should turn
                Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);

                //Actually turn the marine using Lerp()
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
            }
        }
    }
}
