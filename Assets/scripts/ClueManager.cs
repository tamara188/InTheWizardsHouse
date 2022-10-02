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
    private int[] randysHouse;
    private int score = 0;

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
        randysHouse = new int[spriteRenderers.Length];
        for(int i = 0; i < spriteRenderers.Length;i++){
            randysHouse[i] = i;
        }
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
            int randomIndex = (int)Random.Range(0f, spriteRenderers.Length);
            randy = randysHouse[randomIndex];
            spriteRenderers[randy].sprite = sprites[randy].Item2;
        }
        if((int)timer == currentTime + 2)
        {
            spriteRenderers[randy].sprite = sprites[randy].Item1;
        }
         if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == spriteRenderers[randy].name){
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log("hit an active object");
                    //remove clue id from randy's house. replaces current value with another possible value
                    //ie [1,2,3,4] click on object on -> [2,2,3,4] click on object 4 -> [2,2,3,3]]
                    while(true){
                        int randomIndex = (int)Random.Range(0f, spriteRenderers.Length);
                        Debug.Log("randy's house:"+randysHouse.Length);
                        Debug.Log("randomIndex"+randomIndex);
                        if(randomIndex != randy){
                            randysHouse[randy] = randysHouse[randomIndex];
                            break;
                        }
                    }
                    //set sprite to inactive
                    spriteRenderers[randy].sprite = sprites[randy].Item2;
                    //increase score
                    score++;
                }
            }
        }
        if(score == spriteRenderers.Length){
            Debug.Log("you Won!");
        }

    }
    void clickOnClue(){

    }
    
}
