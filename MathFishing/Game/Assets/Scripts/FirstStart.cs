using System.IO;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    void Start()
    {
        if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "BestScores")))
        {
            var bestScoresFolderPath = Path.Combine(Application.persistentDataPath, "BestScores");
            Directory.CreateDirectory(bestScoresFolderPath);
            for (var i = 0; i < 14; i++)
            {
                var fileName = string.Format("{0}.txt", i);
                var filePath = Path.Combine(bestScoresFolderPath, fileName);
                var fileContent = "0";
                File.WriteAllText(filePath, fileContent);
            }
        }
    }
}
