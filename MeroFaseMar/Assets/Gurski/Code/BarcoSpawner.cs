using UnityEngine;

public class BarcoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos, boatDirection, boat, mero;
    private GameObject currentBoat;
    private BarcoMovement boatCode;
    private DiverSpawner diverCode;
    [SerializeField] private float spawnCD;
    [SerializeField] private float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnCD)
        {
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        currentBoat = Instantiate(boat, spawnPos.transform.position, Quaternion.identity);
        boatCode = currentBoat.GetComponent<BarcoMovement>();
        diverCode = currentBoat.GetComponent<DiverSpawner>();
        boatCode.Init(boatDirection);
        diverCode.Init(mero);
    }
}
