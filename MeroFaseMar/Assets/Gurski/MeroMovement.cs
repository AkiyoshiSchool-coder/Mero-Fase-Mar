using UnityEditor.ShaderGraph.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeroMovement : MonoBehaviour
{
    float speed = 5f;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    Vector2 direction;
    Vector2 mouseworld;
    private float meroRotation;
    private bool startMoving = false;
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        
    }

    void Update()
    {
        if(moveAction.WasPressedThisFrame())
        {
            startMoving = true;
        }
        if(startMoving)
        {
            Movement();
        }
        Debug.Log(gameObject.transform.position.z);
    }

    void Movement()
    {
        mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        meroRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, meroRotation - 90);
        transform.position = Vector2.MoveTowards(transform.position, mouseworld, speed*Time.deltaTime);
    }
}
