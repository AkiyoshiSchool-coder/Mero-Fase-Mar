using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BarcoMovement : MonoBehaviour
{
    [SerializeField] private Transform boatPosition;
    [SerializeField] private Transform leavePosition;
    [SerializeField] private float speed;
    [SerializeField] private DiverSpawner diverSpawner;
    [SerializeField] private Transform target;
    private Vector2 direction;
    private float barcoRotation;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
        RotateToTarget();
        if(transform.position == target.transform.position)
            {
                diverSpawner.Diver();
                target = leavePosition;
                direction = target.transform.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
                barcoRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
    }

    void RotateToTarget()
    {
        if(transform.rotation.z != barcoRotation+90)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z+1*Time.deltaTime);
        }
    }
}
