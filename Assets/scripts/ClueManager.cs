using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject metronome;
    private float timer = 0f;
    GameObject[] allClues = GameObject.FindGameObjectsWithTag("Clue");
    public SpriteRenderer clueSprite;
    public Sprite active;
    public Sprite inactive;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    float currentTime = 0f;
    void Update()
    {

        timer += Time.deltaTime;
        Debug.Log(timer);
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
