using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class sceneManager : MonoBehaviour
{
     int n;
   public void OnButtonPress(){
      SceneManager.LoadScene (sceneName:"playArea");
   }
   public void openCredits(){
    Debug.Log("todo, make the credtis and github link show up");
   }
}
