using UnityEngine;
using System.Collections;

public class FoodMovemment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int Decider;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Offset,Offset1,Offset2;
    [SerializeField] private bool CheckMove;
    [SerializeField] private bool isMoving;
    [SerializeField] private float FloatTime;

    void Update()
    {
        if(CheckMove)
        {
            StartCoroutine(RandomDecider());
        }
        Movemment();
    }
    void Movemment()
    {
        switch (Decider)
        {
            case 1:
            Debug.Log("A");
                transform.position = Vector3.MoveTowards(transform.position,  Offset.transform.position,Speed*Time.deltaTime);
                break;
            case 2:
            Debug.Log("B");
                transform.position = Vector3.MoveTowards(transform.position,Offset1.transform.position ,Speed*Time.deltaTime);
                break;
            case 3:
            Debug.Log("C");
                transform.position = Vector3.MoveTowards(transform.position, Offset2.transform.position ,Speed*Time.deltaTime);
                break;
        }
    }
    IEnumerator RandomDecider()
    {
        CheckMove = false; 
        Decider = Random.Range(1,4);
        yield return new WaitForSeconds(FloatTime);
        CheckMove = true;
    }
}
