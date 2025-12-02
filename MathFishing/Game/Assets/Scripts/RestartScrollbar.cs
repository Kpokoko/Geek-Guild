using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RestartScrollbar : MonoBehaviour
{
    public GameObject scrlV;
    private ScrollRect scrlRect;

    private void Start() => scrlRect = scrlV.GetComponent<ScrollRect>();

    private void OnDisable() => scrlRect.normalizedPosition = new Vector2(1,1);
}