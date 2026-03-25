using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    [SerializeField]private GameObject trashParticle;
    void Start()
    {
        if(gameObject.tag == "beacon1")
        {
            InvokeRepeating("TrashSpawn", 5, 3);
        }
        if(gameObject.tag == "beacon2")
        {
            InvokeRepeating("TrashSpawn", 6.5f, 3);
        }
    }


    private void TrashSpawn()
    {
        Instantiate(trashParticle,transform.position,Quaternion.identity);
    }
}
