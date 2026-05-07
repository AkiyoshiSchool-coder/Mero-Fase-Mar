using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    [SerializeField]private GameObject trashParticle;
    public float StartTime;
    public float Cooldown;
    [SerializeField] private GameObject recentTrash;
    [SerializeField] private FoodSpawner foodSpawn;
    void Start()
    {
        if(gameObject.CompareTag("beacon1"))
        {
            InvokeRepeating("TrashSpawn", StartTime, Cooldown);
        }
    }

    private void TrashSpawn()
    {
        recentTrash = Instantiate(trashParticle,transform.position,Quaternion.identity);
        recentTrash.GetComponent<TrashMove>().Init(foodSpawn);
    }
}
