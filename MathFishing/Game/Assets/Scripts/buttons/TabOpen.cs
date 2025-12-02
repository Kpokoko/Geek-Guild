using UnityEngine;
using UnityEngine.UI;

public class TabOpen : MonoBehaviour
{
    public GameObject tab;
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenInfo);

    }

    private void OpenInfo()
    {
        if (tab.activeSelf == false)
            tab.SetActive(true);
    }
}
