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
    void Update()
    {
        if(CheckMove)
        {
            Movemment();
        }
    }
    void Movemment()
    {
        CheckMove = false;
        StartCoroutine(RandomDecider(Decider));
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
        CheckMove = true;
    }
    IEnumerator RandomDecider(int decider)
    {
        yield return new WaitForSeconds(6f);
        Decider = Random.Range(1,4);
    }
}
