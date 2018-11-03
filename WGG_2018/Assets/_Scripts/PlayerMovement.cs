using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool canMove = true;
    [SerializeField] float movementSpeed = 3f;

    void FixedUpdate()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputH, inputV, 0).normalized;

        if(canMove)
            transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
