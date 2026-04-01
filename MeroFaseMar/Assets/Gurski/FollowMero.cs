using UnityEngine;

public class FollowMero : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    void Start()
    {
        offset = new Vector3(1.8f, 0.72f, 0);
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
