using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect (other.gameObject);
		}
	}

	public void Collect (GameObject Player)
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Health) {

			Player.GetComponent<HPManager>().FullMaxHP();

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.PunchPowerUp) {

			Player.GetComponent<PowerUpManager>().HandleCollectedPowerUp();

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.SmallHealth) {

            Player.GetComponent<HPManager>().HandledSmallHealth();

            Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type4) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}

		Destroy (gameObject);
	}
}
