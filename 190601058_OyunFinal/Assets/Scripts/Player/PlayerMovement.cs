using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    public Animator animatorCtrl;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    void Update()
    {
        Vector2 direction = joystick.Direction;
        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * moveSpeed;
        transform.position += movementVector;

        if (movementVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * rotationSpeed);
        }

        bool isWalking = direction.magnitude > 0;
        animatorCtrl.SetBool("isWalking", isWalking);
        animatorCtrl.SetFloat("SpeedValue", direction.magnitude);

    }
}
