using System.Numerics;
using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    private MeroStats merostats;
    public GameObject BarraEsq;
    public GameObject BarraDir;
    public int BarMovement;
    void Start()
    {
        merostats = GetComponent<MeroStats>();
    }

    void Update()
    {
        
    }

    public void BarsMove()
    {
        BarraDir.transform.position = new UnityEngine.Vector3(BarraDir.transform.position.x - BarMovement/4,BarraDir.transform.position.y, BarraDir.transform.position.z);
        BarraEsq.transform.position = new UnityEngine.Vector3(BarraEsq.transform.position.x + BarMovement/4,BarraEsq.transform.position.y, BarraEsq.transform.position.z);
    }
}
