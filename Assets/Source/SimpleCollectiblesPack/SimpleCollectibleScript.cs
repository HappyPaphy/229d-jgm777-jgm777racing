using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Coin, HealthItem, PowerUp1, PowerUp2}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	[SerializeField] private bool rotate; // do you want it to rotate?

	[SerializeField] private float rotationSpeed;

    [SerializeField] private AudioClip collectSound;

    [SerializeField] private GameObject collectEffect;


    [SerializeField] private int coin;
    public int Coin { get { return coin; } set { coin = value; } }



    // Use this for initialization
    void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
		{
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType) 
		{

		}
		else if (CollectibleType == CollectibleTypes.Coin) 
		{
			coin += 300;
		}
		else if (CollectibleType == CollectibleTypes.HealthItem) 
		{

		}
		else if (CollectibleType == CollectibleTypes.PowerUp1) 
		{

		}
		else if (CollectibleType == CollectibleTypes.PowerUp2) 
		{

		}
		

		Destroy (gameObject);
	}
}
