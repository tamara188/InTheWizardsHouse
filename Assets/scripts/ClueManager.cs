using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject metronome;
    private float timer = 0f;
    GameObject[] allClues;
    public SpriteRenderer clueSprite;
    public Sprite active;
    public Sprite inactive;
    private int numActiveItems;
    // Start is called before the first frame update
    void Start()
    {
        allClues = GameObject.FindGameObjectsWithTag("Clue");

    }

    // Update is called once per frame
    float currentTime = 0f;
    void Update()
    {

        timer += Time.deltaTime;
        if((int)timer % 10 == 0)
        {
            currentTime = (int)timer;
            //int randy = (int)Random.Range(0f, allClues.Length+1);
            clueSprite.sprite = active;
        }
        if((int)timer == currentTime + 2)
        {
            clueSprite.sprite = inactive;
        }

    }
}
