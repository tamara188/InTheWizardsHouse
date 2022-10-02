using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class sceneManager : MonoBehaviour
{
     int n;
   public void OnButtonPress(){
      n++;
      Debug.Log("Button clicked " + n + " times.");
      SceneManager.LoadScene (sceneName:"playArea");
   }
}
