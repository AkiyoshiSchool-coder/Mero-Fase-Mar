using UnityEngine;

public class RedeScript : MonoBehaviour
{
    [SerializeField] float timer;
    void Start()
    {
        Destroy(gameObject, 28);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(0, -1.5f* Time.deltaTime, -0.1f*Time.deltaTime);
    }
}
