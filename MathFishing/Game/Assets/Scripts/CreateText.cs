using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CreateText : MonoBehaviour
{
    private TextAsset textFile;
    public GameObject targetObject;
    public string TextToDisplay;
    private TextMeshPro textMeshPro;
    public float reSize = 0.4f;
    public int value;

    public int Count;

    public List<string> ExtraParts;
    private GameObject textObject;
    public List<GameObject> elements = new List<GameObject>();


    void Awake()
    {
        var level = GameObject.FindGameObjectWithTag("LevelCanvas");
        textFile = level.GetComponent<TextHolder>().HoldingText;
        var parsedText = textFile.text.Split(" ").ToList();
        var formulaLength = int.Parse(parsedText[0]);
        parsedText.RemoveAt(0);
        ExtraParts = parsedText
            .Skip(formulaLength)
            .Where(str => str.Count() > 0)
            .ToList();
        textObject = new GameObject("TextMeshPro");
        var amountOfPieces = parsedText.Count;
        value = Random.Range(0, (int)Mathf.Ceil(amountOfPieces * amountOfPieces / (amountOfPieces - 1)));
        Count = formulaLength;
        for (var i = 1; i < formulaLength + 1; i++)
            elements.Add(GameObject.FindGameObjectWithTag("Element" + i.ToString()));
        if (value >= parsedText.Count)
            TextToDisplay = "";
        else
            TextToDisplay = parsedText[Random.Range(0,parsedText.Count)];
        textMeshPro = textObject.AddComponent<TextMeshPro>();
        textMeshPro.alignment = TextAlignmentOptions.Center;
        textMeshPro.transform.localScale = new Vector3(reSize,reSize, 0);
        // Устанавливаем текст и другие параметры
        textMeshPro.text = TextToDisplay;
        textMeshPro.fontSize = 12;
        textMeshPro.color = Color.white;
    }

    void Start()
    {
        // Делаем целевой объект родителем для объекта TextMeshPro
        textObject.transform.SetParent(targetObject.transform);

        textObject.transform.localPosition = Vector3.zero;
        textObject.transform.localRotation = Quaternion.identity;
    }
}
