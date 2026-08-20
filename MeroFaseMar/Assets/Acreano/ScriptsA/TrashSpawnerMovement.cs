using System.Collections;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawnerMovement : MonoBehaviour
{
    [SerializeField] private GameObject P1,P2,P3;
    [SerializeField] private int Decider;
    [SerializeField] private float Speed;
    [SerializeField] private bool CheckMove;
    [SerializeField] private bool isMoving;
    void Update()
    {
        if(CheckMove)
        {
            StartCoroutine(RandomDecider(Decider));
        }
        Movemment();
    }
    void Movemment()
    {
        switch (Decider)
        {
            case 1:
            Debug.Log("A");
                transform.position = Vector3.MoveTowards(transform.position, P1.transform.position ,Speed*Time.deltaTime);
                break;
            case 2:
            Debug.Log("B");
                transform.position = Vector3.MoveTowards(transform.position, P2.transform.position ,Speed*Time.deltaTime);
                break;
            case 3:
            Debug.Log("C");
                transform.position = Vector3.MoveTowards(transform.position, P3.transform.position ,Speed*Time.deltaTime);
                break;
        }
    }
    IEnumerator RandomDecider(int decider)
    {
        CheckMove = false; 
        Decider = Random.Range(1,4);
        yield return new WaitForSeconds(6f);
        CheckMove = true;
    }
}
