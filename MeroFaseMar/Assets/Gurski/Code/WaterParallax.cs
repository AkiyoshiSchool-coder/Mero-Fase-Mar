using UnityEngine;

public class WaterParallax : MonoBehaviour
{
    public GameObject target, resetPosition;
    public float speed;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
        if(transform.position == target.transform.position)
        {
            transform.position = resetPosition.transform.position;
        }
    }
}
