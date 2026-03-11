using UnityEngine;
using UnityEngine.InputSystem;

public class MeroMovement : MonoBehaviour
{
    float speed = 5.01f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(mouseworld);
        Vector3 direction = mouseworld - transform.position;

    }
}
