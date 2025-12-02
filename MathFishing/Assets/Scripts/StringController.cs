using UnityEngine;

public class StringController : MonoBehaviour
{
    public GameObject hook;
    public Transform rodEnd;
    public LineRenderer lineRenderer; 
    private float hookHeight;
    private float hookWidth;
    private Vector3 hookPos;
    private void Start()
    {
        var hookSprite = hook.GetComponent<SpriteRenderer>().sprite;
        hookHeight = hookSprite.rect.yMax / 2800;
        hookWidth = hookSprite.rect.xMax / 2800;
        lineRenderer.positionCount = 2;

        hookPos = new Vector3(hook.transform.position.x + hookWidth, hook.transform.position.y + hookHeight, 0);
        lineRenderer.SetPosition(0, hookPos);
        lineRenderer.SetPosition(1, rodEnd.position);
    }

    private void Update()
    {
        hookPos = new Vector3(hook.transform.position.x + hookWidth, hook.transform.position.y + hookHeight, 0);
        lineRenderer.SetPosition(0, hookPos);
        lineRenderer.SetPosition(1, rodEnd.position);
    }
}
