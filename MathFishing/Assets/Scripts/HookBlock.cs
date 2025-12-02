using UnityEngine;

public class HookBlock : MonoBehaviour
{

    public bool IsActive;
    private float tempSpeed;
    private float time;
    private const float sleepTime = 2f;
    
    void Start()
    {
        tempSpeed = GetComponent<Hook>().speed;
    }

    void Update()
    {
        if (IsActive)
        {
            GetComponent<Hook>().speed = 0;
            time += Time.deltaTime;
            if (time > sleepTime)
            {
                time = 0;
                GetComponent<Hook>().speed = tempSpeed;
                IsActive = false;
            }
        }
    }
}
