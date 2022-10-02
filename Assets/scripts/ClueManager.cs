
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueManager : MonoBehaviour
{
    public GameObject metronome;
    private float timer = 0f;
    GameObject[] allClues;


    public (Sprite,Sprite,Sprite)[] sprites;//preActive,active,inactive
    public SpriteRenderer[] spriteRenderers;
    private int[] randysHouse;
    private int score = 0;

    // all clue sprites
    public Sprite clueOneActive;
    public Sprite clueOneInactive;
    public Sprite clueOnePreactive;
    public Sprite clueTwoActive;
    public Sprite clueTwoInactive;
    public Sprite clueTwoPreactive;

    public Sprite clueThreeActive;
    public Sprite clueThreeInactive;
    public Sprite clueThreePreactive;

    public Sprite clueFourActive;
    public Sprite clueFourInactive;
    public Sprite clueFourPreactive;
        public Sprite clueFiveActive;
    public Sprite clueFiveInactive;
    public Sprite clueFivePreactive;
    //all clue sprite renderers
    public SpriteRenderer clueOne;
    public SpriteRenderer clueTwo;
    public SpriteRenderer clueThree;
    public SpriteRenderer clueFour;
    public SpriteRenderer clueFive;

    private int numActiveItems;
    private SpriteRenderer ActiveObject;
    // Start is called before the first frame update
    void Start()
    {
        allClues = GameObject.FindGameObjectsWithTag("Clue");
        populateSprites();
        randysHouse = new int[spriteRenderers.Length];
        for(int i = 0; i < spriteRenderers.Length;i++){
            randysHouse[i] = i;
        }
        for(int i = 0; i < spriteRenderers.Length;i++){
            spriteRenderers[i].sprite = sprites[i].Item1;
        }
    }
    void populateSprites(){
        sprites = new [] {(clueOnePreactive,clueOneActive,clueOneInactive),
                        (clueTwoPreactive,clueTwoActive,clueTwoInactive),
                        (clueThreePreactive,clueThreeActive,clueThreeInactive),
                        (clueFourPreactive,clueFourActive,clueFourInactive),
                        (clueFivePreactive,clueFiveActive,clueFiveInactive)};
        spriteRenderers = new [] {clueOne,clueTwo,clueThree,clueFour,clueFive};
    }
    // Update is called once per frame
    float currentTime = -2f;
    int randy;
    bool activeFag = true;
    int secToNext = 0;
    int timeLastSecond = 0;
    void Update()
    {

        timer += Time.deltaTime;
        int seconds = (int)(timer % 60f) + 1;
        Debug.Log(seconds);
        if((int)timer != timeLastSecond){
            timeLastSecond++;
        }
        if(seconds % 10 == 0 && activeFag)
        {
            secToNext += 2;
            currentTime = (int)timer;
            int randomIndex = (int)Random.Range(0f, spriteRenderers.Length);
            randy = randysHouse[randomIndex];
            spriteRenderers[randy].sprite = sprites[randy].Item2;
            ActiveObject = spriteRenderers[randy];
            activeFag = false;
        }
        if(seconds == currentTime + 4)
        {
            ActiveObject.sprite = sprites[randy].Item3;
            activeFag = true;
        }
         if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if(hit.collider.gameObject.name == spriteRenderers[randy].name){
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log("hit an active object");
                    ActiveObject.sprite = sprites[randy].Item3;
                    //increase score
                    score++;
                    //remove clue id from randy's house. replaces current value with another possible value
                    //ie [1,2,3,4] click on object on -> [2,2,3,4] click on object 4 -> [2,2,3,3]]
                    while(true){
                        Debug.Log("stuck in while loop");
                        int randomIndex = (int)Random.Range(0f, spriteRenderers.Length);
                        int ri = randysHouse[randomIndex];
                        if(ri != randy){
                            randysHouse[randy] = randysHouse[ri];
                            break;
                        }
                    }
                    //set sprite to inactive
                    
                }
            }
        }
        if(score == spriteRenderers.Length){
            Debug.Log("you Won!");
            SceneManager.LoadScene (sceneName:"cutScene");
        }

    }
    
}
