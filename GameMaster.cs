using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject restartPanel;
    [SerializeField] private AudioSource home;
    public Text timerDisplay;
    bool hasLost;
    public float timer;
    public Animator trans;

    private void Update()
    {
        if (!hasLost) { timerDisplay.text = timer.ToString("F0"); }
        if(timer <= 0)
        {
            trans.SetTrigger("start");
            Invoke("nextLevel",2f);
        }
        else { timer-=Time.deltaTime; }
      
    }

    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        hasLost=true;
        Invoke("Delay",1.5f);
    }
    void Delay()
    {
        restartPanel.SetActive(true);
    }

    public void GotoGamescene()
    {
        home.Play();
        SceneManager.LoadScene("Level1");
    }

    public void RestartGame()
    {
        home.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMenu()
    {
        home.Play();
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
       home.Play();
        Application.Quit();
    }

   
   
}
