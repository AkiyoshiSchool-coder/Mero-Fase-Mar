using UnityEngine;
using UnityEngine.InputSystem;

public class MeroMovement : MonoBehaviour
{
    float speed = 20f;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    Vector2 direction;
    Vector2 mouseworld;
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        
    }

    void Update()
    {
        if(moveAction.WasPressedThisFrame())
        {
            mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log(mouseworld);
            direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        }
        transform.LookAt(direction);
        transform.position = Vector2.MoveTowards(transform.position, mouseworld, speed*Time.deltaTime);
    }
}
