using UnityEngine;

public class RedeSpawner : MonoBehaviour
{
    public GameObject rede;
    public int barcoDuration = 40;
    public float startTime, lowerTimeLimit, upperTimeLimit;
    [SerializeField] float timer;
    private float xSpeed = 3f;
    void Start()
    {
        Destroy(gameObject, barcoDuration);
        InvokeRepeating("Rede", startTime, Random.Range(lowerTimeLimit, upperTimeLimit));
    }

    void Update()
    {
        timer += Time.deltaTime;
        Move();
    }

    void Rede()
    {
        Instantiate(rede, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        transform.Translate(xSpeed*Time.deltaTime, 0, 0);
    }
}