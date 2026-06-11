using UnityEngine;

public class BoomAnimation : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x+(Time.deltaTime*48), 
        transform.localScale.y+(Time.deltaTime*48), transform.localScale.z);
    }
}
