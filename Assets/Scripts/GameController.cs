using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   public bool collisions = true;
   private void Update()
   {
      DebugKeys();
   }

   private void DebugKeys()
   {
      if(Input.GetKeyDown(KeyCode.L)){NextLevel();}
      if(Input.GetKeyDown(KeyCode.C)){collisions = !collisions;}
   }
      
   public void ResetGame()
   {
      StartCoroutine(LoadFirstLevel());
   }

   public void NextLevel()
   {
      StartCoroutine(LoadNextLevel());
   }

   private IEnumerator LoadFirstLevel()
   {
      yield return new WaitForSeconds(2f);
      SceneManager.LoadScene(0);
   }
   
   private IEnumerator LoadNextLevel()
   {
      yield return new WaitForSeconds(2f);
      int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
      SceneManager.LoadScene(nextLevel < SceneManager.sceneCountInBuildSettings ? nextLevel : 0);
   }
}
