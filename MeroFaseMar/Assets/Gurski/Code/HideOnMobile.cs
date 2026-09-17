using UnityEngine;

public class HideOnMobile : MonoBehaviour
{
    void Start()
    {
        if(!Application.platform.Equals(RuntimePlatform.Android))
        {
            gameObject.SetActive(false);
        }
    }
}
