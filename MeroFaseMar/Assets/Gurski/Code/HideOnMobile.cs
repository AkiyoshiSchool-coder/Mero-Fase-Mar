using UnityEngine;
using UnityEngine.SceneManagement;

public class HideOnMobile : MonoBehaviour
{
    void Start()
    {
        if(Application.platform != RuntimePlatform.Android)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
