using UnityEngine;

public class RedeScript : MonoBehaviour
{
    [SerializeField] float timer;
    private float fallSpeed = -1.5f;
    private float zSpeed = -0.1f;
    private int redeDuration = 28;
    void Start()
    {
        Destroy(gameObject, redeDuration);
    }

    void Update()
    {
        timer += Time.deltaTime;
        Move();
    }

    private void Move()
    {
        transform.Translate(0, fallSpeed* Time.deltaTime, zSpeed*Time.deltaTime);
    }
}