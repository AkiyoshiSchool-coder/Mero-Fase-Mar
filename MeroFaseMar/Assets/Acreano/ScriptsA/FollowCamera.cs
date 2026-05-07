using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Follow;
    private Vector3 offset;
    void Start()
    {
        offset = new Vector3(0,0,-10);   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Follow.transform.position +offset;
        Border();
    }

    //limite do mapa
    private void Border()
    {
        // if(transform.position.x > 17.6f)
        // {
        //     transform.position = new Vector3(17.6f, transform.position.y, transform.position.z);
        // }
        // if(transform.position.x < -17.6f)
        // {
        //     transform.position = new Vector3(-17.6f, transform.position.y, transform.position.z);
        // }
        // if(transform.position.y > 9.9f)
        // {
        //     transform.position = new Vector3(transform.position.x, 9.9f, transform.position.z);
        // }
        // if(transform.position.y < -9.9f)
        // {
        //     transform.position = new Vector3(transform.position.x, -9.9f, transform.position.z);
        // }
    }
}
