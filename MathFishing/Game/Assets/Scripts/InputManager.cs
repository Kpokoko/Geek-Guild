using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private TMP_InputField inputField1;
    private TMP_InputField inputField2;
    private TMP_InputField InputField3;
    public List<GameObject> fields;

    public static float?[] Numbers = new float?[3]; 

    void Start()
    {
        inputField1 = fields[0].GetComponent<TMP_InputField>();
        inputField2 = fields[1].GetComponent<TMP_InputField>();
        InputField3 = fields[2].GetComponent<TMP_InputField>();
        inputField1.onEndEdit.AddListener(OnInputField1EndEdit);
        inputField2.onEndEdit.AddListener(OnInputField2EndEdit);
        InputField3.onEndEdit.AddListener(OnInputField3EndEdit);
        
    }

    public void OnInputField1EndEdit(string input)
    {
        if (float.TryParse(input, out float result))
        {    
            Numbers[0] = result;
        }
        else
        {
            Numbers[0] = null;
        }
    }

    public void OnInputField2EndEdit(string input)
    {
        if (float.TryParse(input, out float result))
        {
            Numbers[1] = result;
        }
        else
        {
            Numbers[1] = null;
        }
    }
        public void OnInputField3EndEdit(string input)
    {
        if (float.TryParse(input, out float result))
        {
            Numbers[2] = result;
        }
        else
        {
            Numbers[2] = null;
        }
    }
}
