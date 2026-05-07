using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public GameObject diver;
    public GameObject diverSound;
    [SerializeField] private DiverScript diverScript;
    [SerializeField] private GameObject mero;
    public int startTime, repeatTime;
    void Start()
    {
        InvokeRepeating("Diver", startTime, repeatTime);
        diverScript = diver.GetComponent<DiverScript>();
    }

    void Diver()
    {
        Instantiate(diver, transform.position, Quaternion.identity);
        diverScript.Init(mero);
        Instantiate(diverSound,transform.position,Quaternion.identity);
    }
}
