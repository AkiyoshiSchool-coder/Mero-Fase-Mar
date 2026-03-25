using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject pescador;
    void Start()
    {
        InvokeRepeating("Pescador", 1, 3);
    }

    void Update()
    {
        
    }

    void Pescador()
    {
        Instantiate(pescador, transform.position, Quaternion.identity);
    }
}
