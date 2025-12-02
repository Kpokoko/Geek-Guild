using TMPro;
using UnityEngine;

public class SignActivate : MonoBehaviour
{
    private float time = 0;
    public TextMeshPro TextMeshPro;
    public bool IsActive;
    public TextMeshProUGUI a;
    private const float sleepTime = 2f;
    void Start()
    {
        a =  GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (IsActive)
        {
            a.enabled = true;
            time += Time.deltaTime;
            if (time > sleepTime)
            {
                a.enabled = false;
                time = 0;
                IsActive = false;
            }
        }
    }
}
