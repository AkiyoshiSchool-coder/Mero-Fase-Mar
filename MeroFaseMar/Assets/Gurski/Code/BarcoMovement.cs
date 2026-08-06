using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BarcoMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DiverSpawner diverSpawner;
    [SerializeField] private GameObject direction;
    [SerializeField] private float spawnCD;
    [SerializeField] private bool spawnedDiver = false;
    private float timer = 0;
    
    void Start()
    {
        transform.up = direction.transform.position - transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, direction.transform.position, speed*Time.deltaTime);
        if(timer >= spawnCD && !spawnedDiver)
        {
            diverSpawner.Diver();
            timer = 0;
            spawnedDiver = true;
        }
        if(transform.position == direction.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public void Init(GameObject pos)
    {
        direction = pos;
    }
}
