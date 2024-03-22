using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public float ForceAmount;
    public Transform RootTransform;
    public float Damage;
    public GameObject HitParticle;
    private AudioSource HitSound;
    public GameObject BlockParticle;
    private BlockDetection Block;
    public PowerUpManager powerUpManager;

    private void Start()
    {
        HitSound = GetComponent<AudioSource>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HitSound.Play();
            Block = other.gameObject.GetComponent<BlockDetection>();
            if (Block.IsBlocking)
            {
                Debug.LogWarning("Hit While Blocking " + other.name);
                Instantiate(BlockParticle, other.ClosestPoint(transform.position), BlockParticle.transform.rotation);
                other.GetComponent<HPManager>().TakeDamage(Damage/2);
            }

            else
            {
                Instantiate(HitParticle, other.ClosestPoint(transform.position), HitParticle.transform.rotation);
                if (powerUpManager.HasPowerUp)
                {
                    other.GetComponent<HPManager>().TakeDamage(0.5f);
                }
                else
                {
                    other.GetComponent<HPManager>().TakeDamage(Damage);
                }
                Vector3 direction = other.gameObject.transform.position - RootTransform.position;
                Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
                if (otherRB != null)
                {
                    otherRB.AddForce(direction.normalized * ForceAmount, ForceMode.Force);
                }
            }
        }
    }
}
