using UnityEngine;

public class RedeSpawner : MonoBehaviour
{
    public GameObject rede;
    [SerializeField] float timer;
    void Start()
    {
        Destroy(gameObject, 28);
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
        transform.Translate(3*Time.deltaTime, 0, 0);
    }
}
