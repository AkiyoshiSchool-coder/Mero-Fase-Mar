using UnityEngine;

public class AcessibilityFood : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}