using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    private int foodA = 0;
    private int foodB = 0;
    [SerializeField] public GameObject cursor;
    [SerializeField] private RectTransform cs;
    [SerializeField] private GameObject barra;
    private BarraNivel barraCode;

    void Awake()
    {
        barra = GameObject.Find("BarraNível");
        barraCode = barra.GetComponent<BarraNivel>();
        cs = cursor.GetComponent<RectTransform>();
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
                cs.anchoredPosition = new Rect(cs.anchoredPosition.x + 100, cs.anchoredPosition.y, 10, 30);
            }
            else if(gameObject.CompareTag("FoodB"))
            {
                Debug.Log("comida B");
                foodB++;
                cs.localPosition = new Vector3(cs.localPosition.x - 100, cs.localPosition.y, cs.localPosition.z);
            }
            barraCode.FoodCount();
            Destroy(gameObject);

        }
    }
}
