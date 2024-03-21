using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotating : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotatingSpeed * Time.deltaTime);
    }
}
