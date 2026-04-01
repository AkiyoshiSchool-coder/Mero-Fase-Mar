using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    public bool IsInfected = false;
    private GameObject cursor;
    [SerializeField] private GameObject foodSpawn;
    [SerializeField] private FoodSpawner FS;
    [SerializeField] private RectTransform cs;
    [SerializeField] private GameObject barra;
    [SerializeField] private GameObject Mero;
    [SerializeField] private MeroStats merostats;
    private SpriteRenderer spriteRenderer;
    private BarraNivel barraCode;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Mero = GameObject.Find("Mero");
        merostats = Mero.GetComponent<MeroStats>();
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

    void Update()
    {
        if(IsInfected)
        {
            FoodInfect();
        }
    }

    private void FoodInfect()
    {
        spriteRenderer.color = Color.HSVToRGB(0.75f,1f,0.65f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Head"))
        {
            if(gameObject.CompareTag("FoodA"))
            {
                Debug.Log("comida A");
                merostats.FoodA++;

                FS.FoodsPos.Remove(gameObject.transform.position);
                FS.Foods.Remove(gameObject);

                cs.localPosition = new Vector3(cs.localPosition.x - 48.7f, cs.localPosition.y, cs.localPosition.z);
            }
            else if(gameObject.CompareTag("FoodB"))
            {
                Debug.Log("comida B");
                merostats.FoodB++;

                FS.FoodsPos.Remove(gameObject.transform.position);
                FS.Foods.Remove(gameObject);

                cs.localPosition = new Vector3(cs.localPosition.x + 48.7f, cs.localPosition.y, cs.localPosition.z);
            }
            if(IsInfected)
            {
                merostats.Poison += 1;
            }
            barraCode.FoodCount();
            Destroy(gameObject);

        }
    }
}
