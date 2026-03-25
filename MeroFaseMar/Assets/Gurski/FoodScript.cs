using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    private int foodA = 0;
    private int foodB = 0;
    private GameObject cursor;
    [SerializeField] private GameObject foodSpawn;
    [SerializeField] private FoodSpawner FS;
    [SerializeField] private RectTransform cs;
    [SerializeField] private GameObject barra;
    private BarraNivel barraCode;

    void Awake()
    {
        cursor = GameObject.Find("cursor");
        barra = GameObject.Find("BarraNível");
        foodSpawn = GameObject.Find("Spawner");
        barraCode = barra.GetComponent<BarraNivel>();
        cs = cursor.GetComponent<RectTransform>();
        FS = foodSpawn.GetComponent<FoodSpawner>();
    }
    void Start()
    {
        cs.anchoredPosition = new Vector2(cs.anchoredPosition.x, cs.anchoredPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Head"))
        {
            if(gameObject.CompareTag("FoodA"))
            {
                Debug.Log("comida A");
                foodA++;

                FS.Foods.Remove(gameObject.transform.position);

                cs.localPosition = new Vector3(cs.localPosition.x - 48.7f, cs.localPosition.y, cs.localPosition.z);
            }
            else if(gameObject.CompareTag("FoodB"))
            {
                Debug.Log("comida B");
                foodB++;
                
                FS.Foods.Remove(gameObject.transform.position);

                cs.localPosition = new Vector3(cs.localPosition.x + 48.7f, cs.localPosition.y, cs.localPosition.z);
            }
            barraCode.FoodCount();
            Destroy(gameObject);

        }
    }
}
