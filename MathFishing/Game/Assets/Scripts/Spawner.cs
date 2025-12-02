using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject destroyer;
    private float timer = 0;
    private GameObject fish;
    public GameObject hook;
    public List<GameObject> coloredFishes;
    private List<GameObject> fishes = new List<GameObject>();

    private GameObject level;
    public GameObject LevelStart;

    void Start()
    {
        fish = coloredFishes[Random.Range(0, coloredFishes.Count)];
        level = GameObject.FindGameObjectWithTag("LevelCanvas");
        if (LevelStart.activeInHierarchy)
            return;
        var coolNewFish2 = Instantiate(fish, transform.position, Quaternion.identity);
        coolNewFish2.transform.SetParent(level.transform,false);
        coolNewFish2.transform.position =
            new Vector3(transform.position.x, coolNewFish2.transform.position.y, 0);
        fishes.Add(coolNewFish2);   
    }

    void FixedUpdate()
    {
        if (LevelStart.activeInHierarchy)
            return;
        timer += Time.deltaTime;
        if (timer > 3.0f)
        {
            timer = 0;
            fish = coloredFishes[Random.Range(0, coloredFishes.Count)];
            var coolNewFish2 = Instantiate(fish, transform.position, transform.rotation);
            coolNewFish2.transform.SetParent(level.transform,false);
            coolNewFish2.transform.position =
                new Vector3(transform.position.x, coolNewFish2.transform.position.y, 0);
            fishes.Add(coolNewFish2);   
        }   
        if (fishes.Count >= 100)
        {
            fishes.RemoveRange(0,80);
        }
    }
}
