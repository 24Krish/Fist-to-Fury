using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int playerNumber;
    public float damage;
    public Transform RootTransform;
    public float ForceAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int hitPlayerNumber = other.GetComponent<PlayerNumber>().AssignedPlayerNumber;
            if (hitPlayerNumber != playerNumber)
            {
                other.GetComponent<HPManager>().TakeDamage(damage);
                Vector3 direction = other.gameObject.transform.position - RootTransform.position;
                Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
                if (otherRB != null)
                {
                    otherRB.AddForce(direction.normalized * ForceAmount, ForceMode.Force);
                }
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
