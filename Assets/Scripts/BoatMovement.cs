using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//// Script by Brackeys https://www.youtube.com/watch?v=4HpC--2iowE

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform cam;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSmoothTime = 0.2f;
    private float turnSmoothVeloctiy; 

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3 (horizontal, 0, vertical).normalized;

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVeloctiy, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0); 

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * moveSpeed *Time.deltaTime) ;

        }

    }
}
