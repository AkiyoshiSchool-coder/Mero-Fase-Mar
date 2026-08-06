using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Unity.Mathematics;

public class FoodScript : MonoBehaviour
{
    public bool IsInfected = false;
    private GameObject cursor;
    [SerializeField] private GameObject foodSpawn;
    [SerializeField] private FoodSpawner FS;
    [SerializeField] private RectTransform cs;
    [SerializeField] private GameObject barra;
    [SerializeField] private MeroStats merostats;
    [SerializeField] private PoisonDamage poison;
    [SerializeField] private GameObject skullImage;
    [SerializeField] private GameObject FoodImage;
    private SpriteRenderer spriteRenderer;
    private BarraNivel barraCode;
    public Sprite sprite;
    [SerializeField] private float comidinhas;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }
    void Start()
    {
        cs.anchoredPosition = new Vector2(cs.anchoredPosition.x, cs.anchoredPosition.y);
        Destroy(gameObject, 30);
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
        FoodImage.SetActive(false);
        skullImage.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Head"))
        {
            if(gameObject.CompareTag("FoodA"))
            {
                merostats.FoodCounter();
                
                if(IsInfected)
                {
                    merostats.PoisonUpper();
                    poison.BarsMove();
                }

                FS.FoodsPos.Remove(gameObject.transform.position);
                FS.Foods.Remove(gameObject);

                cs.localPosition = new Vector3(cs.localPosition.x - (comidinhas/100) * 487f, cs.localPosition.y, cs.localPosition.z);
            }
            else if(gameObject.CompareTag("FoodB"))
            {
                merostats.FoodCount--;
                
                if(IsInfected)
                {
                    merostats.Poison += 1;
                    poison.BarsMove();
                }

                FS.FoodsPos.Remove(gameObject.transform.position);
                FS.Foods.Remove(gameObject);

                cs.localPosition = new Vector3(cs.localPosition.x + (comidinhas/100) * 487f, cs.localPosition.y, cs.localPosition.z);
            }
            barraCode.FoodCount();
            Destroy(gameObject);
        }
    }

    public void Init(GameObject mero, GameObject curs, GameObject barraXp, GameObject spawner)
    {
        cursor = curs;
        barra = barraXp;
        foodSpawn = spawner;

        merostats = mero.GetComponent<MeroStats>();
        poison = mero.GetComponent<PoisonDamage>();
        barraCode = barra.GetComponent<BarraNivel>();
        cs = cursor.GetComponent<RectTransform>();
        FS = foodSpawn.GetComponent<FoodSpawner>();
    }
}