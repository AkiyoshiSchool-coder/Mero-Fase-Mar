using UnityEngine;

public class FollowSmth : MonoBehaviour
{
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
    }
}
