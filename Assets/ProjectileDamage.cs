using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int PlayerNumber;
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int hitPlayerNumber = other.GetComponent<CharacterMovement>().PlayerNumber;
            if (hitPlayerNumber != PlayerNumber)
            {
                other.GetComponent<HPManager>().TakeDamage(damage);
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
