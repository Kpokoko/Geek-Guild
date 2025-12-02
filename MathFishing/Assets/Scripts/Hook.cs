using UnityEngine;

public class Hook : MonoBehaviour
{
    public float speed;
    public float y;
    private Transform startPos;
    public const float bottom = -4.5f;
    public bool CatchFish = false;
    public GameObject LevelStart;
    public AudioClip Bubble;
    private AudioSource player;

    void Start()
    {
        startPos = transform;
        y = startPos.position.y;
        gameObject.AddComponent<AudioSource>();
        player = gameObject.GetComponent<AudioSource>();
        player.clip = Bubble;
        player.volume = 0.8f;
        player.playOnAwake = false;
    }



    void Update()
    {
        if (LevelStart.activeInHierarchy)
            return;
        if (CatchFish)
        {
            player.Play();
            transform.position = new Vector3(0, y, 0);
            CatchFish = false;
        }
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase is TouchPhase.Stationary or TouchPhase.Moved)
            && transform.position.y > bottom)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.touchCount > 0 && (Input.GetTouch(0).phase is TouchPhase.Stationary or TouchPhase.Moved)
            && transform.position.y <= bottom)
        {
            transform.Translate(0, 0, 0);
        }
        else if (transform.position.y < y)
        {
            transform.Translate(0, -2 * speed * Time.deltaTime, 0);
        }
    }
}