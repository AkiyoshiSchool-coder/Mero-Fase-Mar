using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodScript : MonoBehaviour
{
    private int foodA = 0;
    private int foodB = 0;
    public GameObject barra;
    private BarraNivel barraCode;

    void Awake()
    {
        barraCode = barra.GetComponent<BarraNivel>();
    }

    void Update()
    {

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
            barraCode.FoodCount();
            Destroy(gameObject);

        }
    }
}
