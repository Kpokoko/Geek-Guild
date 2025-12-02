using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActivator : MonoBehaviour
{
    public List<GameObject> fishes;
    public GameObject Scores;
    public GameObject locker;
    private bool IsFinished = false;
    public static int ButtonClicks;
    private float timer;
    public int Score = 5000;
    private string path;
    public AudioClip WinSound;
    private AudioSource player;

    void Start()
    {
        timer = 0;
        ButtonClicks = 0;
        Score = 5000;
        var number = SceneManager.GetActiveScene().name[^1];
        var extraChar = SceneManager.GetActiveScene().name[^2];
        string levelNumber;
        if (char.IsDigit(extraChar))
            levelNumber = extraChar.ToString() + number.ToString();
        else
            levelNumber = number.ToString();
        var fileName = string.Format("BestScores/{0}.txt", levelNumber);
        path = Path.Combine(Application.persistentDataPath, fileName);
        gameObject.AddComponent<AudioSource>();
        player = gameObject.GetComponent<AudioSource>();
        player.clip = WinSound;
        player.volume = 0.8f;
        player.loop = false;
    }

    void Update()
    {
        if (fishes.Where(fish => fish.activeInHierarchy).Count() == 0 && !IsFinished)
        {
            player.Play();
            IsFinished = true;
            locker.SetActive(true);
            var elapsedTime = (int)timer;
            Score -= elapsedTime * 50;
            Score -= ButtonClicks * 250;
            if (Score < 0)
                Score = 0;
            Scores.GetComponent<TextMeshProUGUI>().text = Score.ToString();
            var reader = new StreamReader(path);
            var readerContent = reader.ReadToEnd();
            reader.Close();
            if (int.Parse(readerContent) < Score)
            {
                var writer = new StreamWriter(path, false);
                writer.WriteLine(Score.ToString());
                writer.Close();
            }
        }
        else
            timer += Time.deltaTime;
    }
}
