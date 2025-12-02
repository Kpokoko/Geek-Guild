using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fish : MonoBehaviour
{

    public GameObject fish;
    public Vector2 startPos;
    public float speed;
    private BoxCollider2D boxCollider;
    public GameObject hookRef;
    public GameObject el1;
    public GameObject el2;
    public GameObject el3;
    public GameObject el4;
    public Hook hook;
    private static bool timerStarted;
    private float time = 0;
    private static List<GameObject> elementsToRemove = new List<GameObject>();
    private static List<GameObject> elements = new List<GameObject>();
    private const float sleepTime = 2f;
    private GameObject sign;
    private static List<string> extraPartsOfFormula;

    void Start()
    {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        hookRef = GameObject.FindGameObjectWithTag("Hook");
        hook = hookRef.GetComponent<Hook>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector2(5f, 3.0f);
        var fishSide = Mathf.Sign(fish.transform.position.x);
        var verticalPosition = Random.Range(-1.25f, -4f);
        var randomSpeed = Random.Range(-0.003f, -0.01f);
        startPos = new Vector2(1, verticalPosition);
        if (fishSide > 0)
            speed = -randomSpeed;
        else if (fishSide < 0)
            speed = randomSpeed;
        extraPartsOfFormula = GetComponentInChildren<CreateText>().ExtraParts;
        elements = GetComponentInChildren<CreateText>().elements;
        transform.Translate(0, verticalPosition, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {
            foreach(var el in elements)
                SetVisible(el);
            hook.CatchFish = true;
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroyer"))
            Destroy(gameObject);
    }

    private void SetVisible(GameObject el)
    {
        var textEl = el.GetComponent<TextMeshProUGUI>().text;
        var myComponent = GetComponentInChildren<TextMeshPro>();
        if (myComponent.text == textEl && el.GetComponent<TextMeshProUGUI>().enabled != true)
        {
            el.GetComponent<TextMover>().IsMoving = true;
            el.GetComponent<TextMeshProUGUI>().enabled = true;
            el.transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (el.GetComponent<TextMeshProUGUI>().enabled == true && myComponent.text == textEl)
            Set("ExistedFish", el);
        else if(myComponent.text == "")
            Set("EmptyFish", el);
        else if (extraPartsOfFormula.Contains(myComponent.text))
            Set("WrongFish", el);
    }

    private void Set(string tagName, GameObject el)
    {
        elementsToRemove.Add(el);
        sign = GameObject.FindGameObjectWithTag(tagName);
        sign.GetComponent<SignActivate>().IsActive = true;
        hook.GetComponent<HookBlock>().IsActive = true;
        el.GetComponent<TextMeshProUGUI>().color = Color.red;
        timerStarted = true;
    }

    private void CheckTime()
    {
        time += Time.deltaTime;
        if (time >= sleepTime)
        {
            foreach (var el in elementsToRemove)
            {
                el.GetComponent<TextMeshProUGUI>().enabled = false;
                el.transform.position = new Vector3(transform.position.x, 0, 0);
                el.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            timerStarted = false;
            time = 0;
            elementsToRemove.Clear();
        }
    }

    void FixedUpdate()
    {
        if (timerStarted)
            CheckTime();
        transform.Translate(startPos.x * (-speed), 0, 0);
        End();
    }

    private void End()
    {
        var ended = true;
        foreach(var el in elements)
            if (el.GetComponent<TextMeshProUGUI>().enabled == false || el.GetComponent<TextMover>().IsMoving == true)
                ended = false;
        if (ended)
            SceneManager.LoadScene(string.Format("Harpoon{0}", gameObject.GetComponentInParent<TextHolder>().HoldingText.name));
    }
}
