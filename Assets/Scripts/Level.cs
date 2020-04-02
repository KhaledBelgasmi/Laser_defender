using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2;
        public void LoadGameOver() 
        {
        StartCoroutine(WaitAndLoad());        
        }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }

    public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
            FindObjectOfType<GameSession>().ResetGame();
    }

        public void LoadStartMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

 
    
}
