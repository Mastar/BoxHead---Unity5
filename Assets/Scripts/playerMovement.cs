using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    float movementSpeedX = 6f;
    float movementSpeedZ = 7f;

    float airSpeed = 1.5f;
    float jumpSpeed = 7;

    Vector3 direction;

    CharacterController characterController;
    float verticalVelocity = 0;

    // Use this for initialization
    void Start()
    {
      
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        direction = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }
        direction.x *= movementSpeedX;
        direction.z *= movementSpeedZ;

        //float forwardSpeed = Input.GetAxis("Vertical") * movementSpeedX;
      //  float sideSpeed = Input.GetAxis("Horizontal") * movementSpeedZ;

        if (characterController.isGrounded)
        {
            verticalVelocity = Physics.gravity.y;
        }
        else
        {
            direction.x *= airSpeed;
            direction.z *= airSpeed;

            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }


        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        //Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        //if (speed.magnitude > 1)
        //    speed = speed.normalized;
        direction.y = verticalVelocity;

        //speed = transform.rotation * speed;


        characterController.Move(direction * Time.deltaTime);
    }

}
