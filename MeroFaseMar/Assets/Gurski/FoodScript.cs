using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodScript : MonoBehaviour
{
    [SerializeField] int foodA = 0;
    [SerializeField] int foodB = 0;
    [SerializeField] int totalFood = 0;
    public GameObject barra;
    private BarraNivel barraCode;

    void Awake()
    {
        barraCode = barra.GetComponent<BarraNivel>();
    }

    void Update()
    {
        Debug.Log(gameObject.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Head"))
        {
            if(gameObject.CompareTag("FoodA"))
            {
                Debug.Log("comida A");
                foodA++;
            }
            else if(gameObject.CompareTag("FoodB"))
            {
                Debug.Log("comida B");
                foodB++;
            }
            Destroy(gameObject);

        }
    }
}
