using UnityEngine;

public class StaticFish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
