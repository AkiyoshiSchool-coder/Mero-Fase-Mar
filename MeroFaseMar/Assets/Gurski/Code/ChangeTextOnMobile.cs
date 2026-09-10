using UnityEngine;
using TMPro;

public class ChangeTextOnMobile : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public string mobileText, pcText;

    void Start()
    {
        if(Application.platform.Equals(RuntimePlatform.Android))
        {
            texto.text = mobileText;
        }
        else
        {
            texto.text = pcText;
        }
    }

}
