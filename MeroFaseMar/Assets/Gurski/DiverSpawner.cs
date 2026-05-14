using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public GameObject diver;
    [SerializeField] private GameObject currentDiver;
    public GameObject diverSound;
    [SerializeField] private DiverScript diverScript;
    [SerializeField] private GameObject mero;
    public int startTime, repeatTime;
    void Start()
    {

    }

    public void Diver()
    {
        currentDiver = Instantiate(diver, transform.position, Quaternion.identity);
        diverScript = currentDiver.GetComponent<DiverScript>();
        diverScript.Init(mero);
        Instantiate(diverSound,transform.position,Quaternion.identity);
    }
}
