using UnityEngine;

public class BoomAnimation : MonoBehaviour
{
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] private float radiusIncreaseSpeed;
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        collider.radius += radiusIncreaseSpeed*Time.deltaTime;
    }
}