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
        string [] t = {"hello wizard","hello ghost hunter.","shall we go on to the game?","sure thing","this text shows after the game."};
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
