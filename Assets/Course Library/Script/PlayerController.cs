using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    private enum PlayerIndex { player1, player2 }
    [SerializeField] PlayerIndex playerIndex;

    [SerializeField] KeyCode moveForwardKey = KeyCode.W; // KeyCode.I
    [SerializeField] KeyCode moveBackwardKey = KeyCode.S; // KeyCode.K
    [SerializeField] KeyCode rotateLeftKey = KeyCode.A; // KeyCode.J
    [SerializeField] KeyCode rotateRightKey = KeyCode.D; // KeyCode.L

    [SerializeField] private float moveSpeed = 20f, rotateSpeed = 90f;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();

       
    }

    private void PlayerMovement()
    {
        if(Input.GetKey(moveForwardKey))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(moveBackwardKey))
        {
            transform.Translate(Vector3.forward * -moveSpeed/2 * Time.deltaTime);
        }

        if (Input.GetKey(rotateLeftKey) && (Input.GetKey(moveForwardKey) || Input.GetKey(moveBackwardKey)))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(rotateRightKey) && (Input.GetKey(moveForwardKey) || Input.GetKey(moveBackwardKey)))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}