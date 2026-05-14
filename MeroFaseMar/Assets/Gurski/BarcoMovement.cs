using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BarcoMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DiverSpawner diverSpawner;
    [SerializeField] private Transform direction;
    [SerializeField] private float boatDuration = 50;
    private float timer = 0;
    void Start()
    {
        Destroy(gameObject, boatDuration);
        transform.LookAt(direction);
    }

    void Update()
    {
        Debug.Log(timer);
        timer += Time.fixedDeltaTime;
        transform.position = Vector2.MoveTowards(transform.position, direction.transform.position, speed*Time.deltaTime);
        if(timer == 20f)
        {
            diverSpawner.Diver();
        }
    }
}
