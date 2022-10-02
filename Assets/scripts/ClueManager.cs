using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject metronome;
    private float timer = 0f;
    GameObject[] allClues;


    public (Sprite,Sprite)[] sprites;
    public SpriteRenderer[] spriteRenderers;

    // all clue sprites
    public Sprite clueOneActive;
    public Sprite clueOneInactive;
    public Sprite clueTwoActive;
    public Sprite clueTwoInactive;
    //all clue sprite renderers
    public SpriteRenderer clueOne;
    public SpriteRenderer clueTwo;
    private int numActiveItems;
    // Start is called before the first frame update
    void Start()
    {
        allClues = GameObject.FindGameObjectsWithTag("Clue");
        populateSprites();
    }
    void populateSprites(){
        sprites = new [] {(clueOneActive,clueOneInactive),(clueTwoActive,clueTwoInactive)};
        spriteRenderers = new [] {clueOne,clueTwo};
    }
    // Update is called once per frame
    float currentTime = 0f;
    int randy;
    void Update()
    {

        timer += Time.deltaTime;
        if((int)timer % 10 == 0)
        {
            currentTime = (int)timer;
            randy = (int)Random.Range(0f, spriteRenderers.Length);
            spriteRenderers[randy].sprite = sprites[randy].Item2;
            //clueSprite.sprite = active;
        }
        if((int)timer == currentTime + 2)
        {
            spriteRenderers[randy].sprite = sprites[randy].Item1;
            //clueSprite.sprite = inactive;
        }

    }
}
