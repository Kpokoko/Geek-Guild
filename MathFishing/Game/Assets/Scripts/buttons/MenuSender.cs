
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSender : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendToMenu);
    }

    private void SendToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
