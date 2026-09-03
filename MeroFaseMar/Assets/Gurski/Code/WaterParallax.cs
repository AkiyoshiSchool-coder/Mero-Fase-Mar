using UnityEngine;

public class WaterParallax : MonoBehaviour
{
    public Transform target, resetPosition;
    public float speed;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        if(transform.position == target.transform.position)
        {
            transform.position = resetPosition.position;
        }
    }
}
