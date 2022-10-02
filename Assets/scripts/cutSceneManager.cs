using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class cutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] textCont;
    private static int textNum = 0;
    public Text txt;
    void Start(){
        string [] t = {"Hello, Welcome to my home. I seem to be having an issue with a ghost and was recommended you for the job. Jeez, it's just one thing after another these days. First my cat is knocking everying thing i own down, and now that I've got my cat spelled not to, a ghost comes along! Thanks for helping me out.","You can move left and right with the a and d keys. click on glowing objects to earn points. You'll find the ghost when you have 5 points","I've got a magic metronome that will make the last the the ghost toughed glow. It'll only work once every 10 seconds, but that should be more than long enough for you.","Ready to get started?","Great job! It was my cat all along. I guess instead of making a spell that stopped her from knocking things over, I accedently gave her telekikesis. Here's your pay, and thanks for all your help!"};
        textCont = t;
        txt.text = textCont[textNum];
    }
    public void nextButton(){
        textNum++;
        if(textNum == 4){
            SceneManager.LoadScene (sceneName:"playArea");
        }else{
            txt.text = textCont[textNum];
        }
        
    }
}
