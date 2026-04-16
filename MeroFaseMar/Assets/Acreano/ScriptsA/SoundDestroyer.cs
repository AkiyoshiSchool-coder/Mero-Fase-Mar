using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int time;
    void Start()
    {
        Destroy(gameObject,time*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
