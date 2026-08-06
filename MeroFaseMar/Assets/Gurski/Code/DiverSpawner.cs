using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public GameObject diver;
    [SerializeField] private GameObject currentDiver;
    [SerializeField] private bool spawn = false;
    [SerializeField] private DiverScript diverScript;
    [SerializeField] private GameObject mero;
    [SerializeField] private float startTime, repeatTime;

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
    }

    public void Init(GameObject obj)
    {
        mero = obj;
    }
}
