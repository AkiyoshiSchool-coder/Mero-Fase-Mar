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
                transform.position = Vector3.MoveTowards(transform.position, P1.transform.position ,Speed*Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, P2.transform.position ,Speed*Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, P3.transform.position ,Speed*Time.deltaTime);
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
