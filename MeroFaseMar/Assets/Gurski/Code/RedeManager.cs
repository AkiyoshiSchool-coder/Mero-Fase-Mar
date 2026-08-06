using UnityEngine;

public class RedeManager : MonoBehaviour
{
    [SerializeField] private float startTime, repeat;
    [SerializeField] private GameObject redeBoat, spawnPos;

    void Start()
    {
        InvokeRepeating("spawnBarco", startTime, repeat);
    }

    void spawnBarco()
    {
        Instantiate(redeBoat, spawnPos.transform.position, Quaternion.identity);
    }
}