using UnityEngine;
using UnityEngine.UI;

public class GraphUpdate : MonoBehaviour
{
    public GameObject graph;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GraphUpd);
    }

    private void GraphUpd()
    {
        graph.GetComponent<FormulasScript>().StartDrawing();
        MenuActivator.ButtonClicks++;
    }
}
