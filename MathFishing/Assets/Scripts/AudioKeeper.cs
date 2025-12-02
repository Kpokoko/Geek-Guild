using UnityEngine;

public class AudioKeeper : MonoBehaviour
{
    public static AudioKeeper instance = null;
    public AudioClip audioClip;
    void Awake()
    {
        if (instance == null)
        {
            var innerobj = new GameObject("AudioPlayer");
            innerobj.AddComponent<AudioSource>();
            var comp = innerobj.GetComponent<AudioSource>(); 
            innerobj.transform.parent = gameObject.transform;
            comp.clip = audioClip;
            comp.loop = true;
            comp.Play();
            comp.volume = 0.6f;
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
