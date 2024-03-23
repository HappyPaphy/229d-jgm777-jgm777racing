using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
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

    [SerializeField] private float moveForce = 10000f;
    [SerializeField] private float moveSpeed = 20f, rotateSpeed = 90f;
    [SerializeField] private float rotateLimitBalanced;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 COM; // center Of Mass

    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private GameObject explosionEffect;

    [SerializeField] private int curHP;
    public int CurHP { get { return curHP; } set { curHP = value; } }

    [SerializeField] private int maxHP;
    public int MaxHP { get { return maxHP; } set { maxHP = value; } }

    void Start()
    {
        curHP = maxHP;
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
        PlayerRotationLimitControl();
    }

    private void PlayerMovement()
    {
        if(Input.GetKey(moveForwardKey))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            /*Vector3 force = transform.TransformDirection(Vector3.forward) * moveSpeed;
            rb.AddForce(force);*/
        }
        else if (Input.GetKey(moveBackwardKey))
        {
            transform.Translate(Vector3.forward * -moveSpeed/2 * Time.deltaTime);
            /*Vector3 force = transform.TransformDirection(Vector3.back) * moveSpeed/2;
            rb.AddForce(force);*/
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "explosionBarrel")
        {
            TakeDamage(20);
        }
    }

    private void PlayerRotationLimitControl()
    {
        rb.centerOfMass = COM;

        if(transform.rotation.z < -50)
        {
            COM.x--;
            transform.Rotate(Vector3.forward * rotateLimitBalanced * Time.deltaTime, Space.Self);
        }
        else if (transform.rotation.z > 50)
        {
            COM.x++;
            transform.Rotate(Vector3.back * rotateLimitBalanced * Time.deltaTime, Space.Self);
        }
        else
        {
            COM.x = 0;
        }
    }

    private void TakeDamage(int damage)
    {
        curHP -= damage;

        if (curHP <= 0)
        {
            Debug.Log("Player Died");

            if (explosionSound)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            if (explosionEffect)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            Destroy(this);

            return;
        }

        if (curHP <= 0)
        {
            curHP = 0;
        }
    }
}
