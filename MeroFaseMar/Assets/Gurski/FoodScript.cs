using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodScript : MonoBehaviour
{
    void Update()
    {
        Debug.Log(gameObject.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("aaaa");
        if(collider.gameObject.CompareTag("Head"))
        {
            Destroy(gameObject);
        }
    }
}
