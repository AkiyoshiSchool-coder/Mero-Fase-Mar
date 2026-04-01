using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    [SerializeField]private GameObject trashParticle;
    public float StartTime;
    public float Cooldown;
    void Start()
    {
        if(gameObject.tag == "beacon1")
        {
            InvokeRepeating("TrashSpawn", StartTime, Cooldown);
        }
        if(gameObject.tag == "beacon2")
        {
            InvokeRepeating("TrashSpawn", StartTime+1.5f, Cooldown);
        }
    }


    private void TrashSpawn()
    {
        Instantiate(trashParticle,transform.position,Quaternion.identity);
    }
}
