using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Follow;
    private Vector3 offset;
    [SerializeField] private float xLimit, yLimit;
    void Start()
    {
        offset = new Vector3(0,0,-10);   
    }

    void Update()
    {
        gameObject.transform.position = Follow.transform.position +offset;
        // Border();
    }

    private void Border() // Limite do mapa
    {
        if(transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.y > yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }
        if(transform.position.y < -yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit, transform.position.z);
        }
    }
}
