using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Coin, HealthItem, PowerUp1, PowerUp2, Ring}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	[SerializeField] private bool rotate; // do you want it to rotate?

	[SerializeField] private float rotationSpeed;

    [SerializeField] private AudioClip collectSound;

    [SerializeField] private GameObject collectEffect;

    //[SerializeField] private int coin;
    
    //public int Coin { get { return coin; } set { coin = value; } }

	[SerializeField] public PlayerController playerController;

	public static SimpleCollectibleScript instance;

    // Use this for initialization
    void Start () 
	{
		instance = this;
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
            Collect();
		}
	}

	public void Collect()
	{
		/*if(collectSound)
		{
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
			
		if(collectEffect)
		{
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }*/
			
		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType) 
		{

		}
		else if (CollectibleType == CollectibleTypes.Coin) 
		{
			playerController.CollectEfect(0); // 0 = Coin
            playerController.CollectSound(0); // 0 = Coin
            //coin += 300;
            Destroy(gameObject);
        }
		else if (CollectibleType == CollectibleTypes.HealthItem) 
		{
            playerController.CollectEfect(1); // 1 = health
            playerController.CollectSound(1); // 1 = health
            playerController.curHP += 50;
            Destroy(gameObject);
        }
		else if (CollectibleType == CollectibleTypes.PowerUp1) 
		{

		}
		else if (CollectibleType == CollectibleTypes.PowerUp2) 
		{

		}
        else if (CollectibleType == CollectibleTypes.Ring)
        {
            playerController.numRing++;

			bool isOneTimePlay = false;
            if (playerController.numRing >= 14 && isOneTimePlay == false)
            {
				isOneTimePlay = true;
                SceneChanger.instance.YouWinUI();
            }

            playerController.CollectEfect(2); // 2 = ring
            playerController.CollectSound(2); // 2 = ring
            Destroy(gameObject);
        }
	}
}
