using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        var sceneName = SceneManager.GetActiveScene().name[^1];
        var preLastSymbol = SceneManager.GetActiveScene().name[^2];
        if (char.IsDigit(preLastSymbol))
        {
            var sceneNumber = int.Parse(preLastSymbol.ToString() + sceneName.ToString());
            SceneManager.LoadScene(string.Format("Level{0}", ++sceneNumber));
        }
        else
        {
            var sceneNumber = int.Parse(sceneName.ToString());
            SceneManager.LoadScene(string.Format("Level{0}", ++sceneNumber));
        }
    }
}
