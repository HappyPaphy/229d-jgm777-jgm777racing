using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
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

    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private ParticleSystem explosionEffect;

    [SerializeField] private ParticleSystem[] collectEffect;
    [SerializeField] private AudioSource[] collectSound;

    [SerializeField] private MeshRenderer[] meshRenderer;
    [SerializeField] private Collider[] collider;
    [SerializeField] private bool isPlayerDied = false;
    [SerializeField] private bool isOnGround = false;

    [SerializeField] public int numRing = 0;
    [SerializeField] public SceneChanger sceneChanger;

    public int curHP;
    public int CurHP { get { return curHP; } set { curHP = value; } }

    [SerializeField] public int maxHP = 100;
    public int MaxHP { get { return maxHP; } set { maxHP = value; } }

    public static PlayerController instance;

    void Start()
    {
        //StartCoroutine(MoveOnstart());
        curHP = maxHP;
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (curHP >= 100)
        {
            curHP = 100;
        }

        PlayerMovement();
        PlayerRotationLimitControl();
    }

    private void PlayerMovement()
    {
        if(!isPlayerDied)
        {
            if(isOnGround)
            {
                if (Input.GetKey(moveForwardKey))
                {
                    /*transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);*/
                    /*Vector3 force = transform.TransformDirection(Vector3.forward) * moveSpeed;
                    rb.AddForce(force);*/
                    rb.AddForce(rb.transform.forward * moveForce * Time.deltaTime);
                }
                else if (Input.GetKey(moveBackwardKey))
                {
                    /*transform.Translate(Vector3.forward * -moveSpeed / 2 * Time.deltaTime);*/
                    /*Vector3 force = transform.TransformDirection(Vector3.back) * moveSpeed/2;
                    rb.AddForce(force);*/
                    rb.AddForce(rb.transform.forward * -moveForce / 2 * Time.deltaTime);
                }
            }

            if (Input.GetKey(rotateLeftKey))
            {
                transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(rotateRightKey))
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "explosionBarrel")
        {
            TakeDamage(20);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
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
            Die();
            Debug.Log("Player Died");

            if (explosionSound)
            {
                explosionSound.Play();
            }

            if (explosionEffect)
            {
                explosionEffect.Play();
                //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            StartCoroutine(DestroyGameObjectOnTime(4f));

            return;
        }

        if (curHP <= 0)
        {
            curHP = 0;
        }
    }

   private void Die()
   {
        isPlayerDied = true;
        sceneChanger.YouLoseUI();
    }

    IEnumerator DestroyGameObjectOnTime(float time)
    {
        Debug.Log("Destroying Object");

        foreach(MeshRenderer meshRndr in meshRenderer)
        {
            meshRndr.enabled = false;
        }

        foreach (Collider col in collider)
        {
            col.enabled = false;
        }

        yield return new WaitForSeconds(time);
        SceneChanger.instance.RestartScene();
    }

    //index0 = coin, index1 = health, index2 = ring
    public void CollectEfect(int index)
    {
        collectEffect[index].Play();
    }

    public void CollectSound(int index)
    {
        collectSound[index].Play();
    }

    /*IEnumerator MoveOnstart()
    {
        rb.AddForce(rb.transform.forward * moveForce * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }*/

    /*public static implicit operator float(PlayerController v)
    {
        throw new NotImplementedException();
    }*/
}
