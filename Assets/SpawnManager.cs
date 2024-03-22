using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float Timer = 30f;
    [HideInInspector] public float CurrentTimer;
    public GameObject[] SpawnPoint;
    public string[] CollectibleNames;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer -= Time.deltaTime;
        if(CurrentTimer <= 0)
        {
            SpawnCollectible();
            CurrentTimer = Timer;
        }
    }

    private void SpawnCollectible()
    {
        GameObject Pickup;
        int Index;
        Index = Random.Range(0, CollectibleNames.Length);
        string CollectibleName = CollectibleNames[Index];
        Pickup = Resources.Load<GameObject>(CollectibleName);
        Index = Random.Range(0, SpawnPoint.Length);
        GameObject Spawn = SpawnPoint[Index];
        var Spawned = Instantiate(Pickup, Spawn.transform.position, Quaternion.identity);
        var collectibleType = Spawned.GetComponent<SimpleCollectibleScript>().CollectibleType;
        if(collectibleType == CollectibleTypes.PunchPowerUp)
        {
            Spawned.transform.position += Vector3.up * 2;
        }
    }
}
