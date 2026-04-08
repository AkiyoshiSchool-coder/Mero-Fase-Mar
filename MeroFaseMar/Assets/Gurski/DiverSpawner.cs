using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public GameObject diver;
    public int startTime, repeatTime;
    void Start()
    {
        InvokeRepeating("Diver", startTime, repeatTime);
    }

    void Diver()
    {
        Instantiate(diver, transform.position, Quaternion.identity);
    }
}
