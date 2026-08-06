using UnityEngine;

public class RedeSpawner : MonoBehaviour
{
    public GameObject rede;
    private int barcoDuration = 28;
    [SerializeField] float timer;
    private float xSpeed = 3f;
    void Start()
    {
        Destroy(gameObject, barcoDuration);
        InvokeRepeating("Rede", 4, Random.Range(4f, 10f));
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