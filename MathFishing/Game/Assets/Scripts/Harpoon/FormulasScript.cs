using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormulasScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private float k;
    private float b;
    private float c;
    private float timer;
    private float minX = -3f;
    private float maxX = 3f;
    public GameObject sign;
    private bool timerStarted;
    public Button button;
    private string sceneName;
    public GameObject destroyer;
    public AudioClip Audio;
    private AudioSource audioComponent;
    void Start()
    {
        FormulasStorage.Start();
        gameObject.AddComponent<AudioSource>();
        audioComponent = gameObject.GetComponent<AudioSource>();
        audioComponent.clip = Audio;
        audioComponent.volume = 0.8f;
        audioComponent.playOnAwake = false;
    }

    public void StartDrawing()
    {
        sceneName = SceneManager.GetActiveScene().name;
        var tempNumbers = InputManager.Numbers;
        var tempK = InputManager.Numbers[0];
        var tempB = InputManager.Numbers[1];
        var tempC = InputManager.Numbers[2];
        if (tempNumbers.All(item => item != null) && FormulasStorage.CheckingsStorage[sceneName](tempK, tempB, tempC))
        {
            k = (float)tempK;
            b = (float)tempB;
            c = (float)tempC;
            StartCoroutine(DrawGraph());
        }
        else
        {
            timerStarted = true;
            sign.SetActive(true);
            button.interactable = false;
        }
    }


    private IEnumerator DrawGraph()
    {
        lineRenderer.positionCount = 0;
        var place = 1;
        button.interactable = false;
        audioComponent.Play();
        if (sceneName[^1] == '9' || (sceneName[^2]== '1' && + sceneName[^1] == '0'))
        {
            minX = -2.5f;
            maxX = 2.5f;
        }
        else if (sceneName[^1] == '3')
        {
            minX = 0.00001f;
            maxX = 3f;
        }
        else
        {
            minX = -3f;
            maxX = 3f;
        }
        for (var x = minX; x < maxX; x += 0.03f)
        {
            var y = FormulasStorage.FormulaStorage[sceneName](x, k, b, c) - 2.63f;
            if (y < -150 || y > 150)
                continue;
            destroyer.transform.position = new Vector3(x,y,0);
            lineRenderer.positionCount = place;
            lineRenderer.SetPosition(place -1, new Vector3(x, y, 0));
            place++;
            yield return new WaitForSeconds(0);
        }
        button.interactable = true;
    }

    void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                sign.SetActive(false);
                timerStarted = false;
                button.interactable = true;
            }
        }
    }
}
