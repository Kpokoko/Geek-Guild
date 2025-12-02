using System.IO;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    string path;
    void Start()
    {
        var number = gameObject.name[^1];
        var extraChar = gameObject.name[^2];
        string levelNumber;
        if (char.IsDigit(extraChar))
            levelNumber = extraChar.ToString() + number.ToString();
        else
            levelNumber = number.ToString();
        path = Path.Combine(Application.persistentDataPath, string.Format("BestScores/{0}.txt", levelNumber));
        using (var reader = new StreamReader(path))
        {
            var fileContent = reader.ReadToEnd();
            gameObject.GetComponent<TextMeshProUGUI>().text += fileContent;
        }
    }
}
