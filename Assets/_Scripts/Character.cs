using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character : MonoBehaviour
{
    public CharacterController player;
    public float movementSpeed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // MOVEMENT & ALIGNMENT

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) 
        {

            float targetAngle = Mathf. Atan2(direction.x, direction.z) * Mathf.Rad2Deg; //angle to rotate player, to look in movement direction
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            player.Move(direction * movementSpeed * Time.deltaTime); //move player

            //Debug.Log("v = " + player.velocity);
        }

    }
}

