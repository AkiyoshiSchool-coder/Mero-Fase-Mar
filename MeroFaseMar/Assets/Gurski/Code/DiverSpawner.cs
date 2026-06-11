using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public GameObject diver;
    [SerializeField] private GameObject currentDiver;
    public GameObject diverSound;
    [SerializeField] private bool spawn = false;
    [SerializeField] private DiverScript diverScript;
    [SerializeField] private GameObject mero;
    public int startTime, repeatTime;

    void Start()
    {
        if(spawn)
        {
            InvokeRepeating("Diver", startTime, repeatTime);
        }
    }

    public void Diver()
    {
        currentDiver = Instantiate(diver, transform.position, Quaternion.identity);
        diverScript = currentDiver.GetComponent<DiverScript>();
        diverScript.Init(mero);
        Instantiate(diverSound,transform.position,Quaternion.identity);
    }

    public void Init(GameObject obj)
    {
        mero = obj;
    }
}
