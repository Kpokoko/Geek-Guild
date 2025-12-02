using UnityEngine;

public class TextMover : MonoBehaviour
{
    public bool IsMoving;
    private float speed;
    public Vector3 target;

    void Start()
    {
        speed = 3f;
        target = transform.position;
    }

    void FixedUpdate()
    {
        if (IsMoving && transform.position.y <= target.y)
        {
            if (transform.position.y == 0)
                transform.position = new Vector3(target.x, 0, 0);
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
            IsMoving = false;
    }
}
