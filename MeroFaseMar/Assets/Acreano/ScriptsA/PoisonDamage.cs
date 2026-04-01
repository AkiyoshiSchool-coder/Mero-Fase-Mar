using System.Numerics;
using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    private MeroStats merostats;
    public GameObject BarraEsq;
    public GameObject BarraDir;
    void Start()
    {
        merostats = GetComponent<MeroStats>();
    }

    private void BarsMove()
    {
        BarraDir.transform.position = new UnityEngine.Vector3(BarraDir.transform.position.x + (49*merostats.Poison),BarraDir.transform.position.y, BarraDir.transform.position.z);
    }
}
