using System.Numerics;
using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    private MeroStats merostats;
    public GameObject BarraEsq;
    public GameObject BarraDir;
    public UnityEngine.Vector3 startPosEsq, startPosDir;
    public int BarMovement;
    void Start()
    {
        merostats = GetComponent<MeroStats>();
        startPosEsq = BarraEsq.transform.position;
        startPosDir = BarraDir.transform.position;
    }

    void Update()
    {
        
    }

    public void BarsMove()
    {
        BarraDir.transform.position = new UnityEngine.Vector3(BarraDir.transform.position.x - BarMovement/2,BarraDir.transform.position.y, BarraDir.transform.position.z);
        BarraEsq.transform.position = new UnityEngine.Vector3(BarraEsq.transform.position.x + BarMovement/2,BarraEsq.transform.position.y, BarraEsq.transform.position.z);
    }

    public void Heal()
    {
        BarraDir.transform.position = startPosDir;
        BarraEsq.transform.position = startPosEsq;
    }
}
