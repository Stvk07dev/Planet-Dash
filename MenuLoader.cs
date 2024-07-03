using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{

    public Animator animator;
    public float transitionTime;
    [SerializeField] AudioSource _home;
   public void clickPlay()
    {
        _home.Play(); Invoke("playDelay", 1.5f); 
    }

    public void clickExit() 
    { 
        Application.Quit();
    }
    void playDelay() { 
        SceneManager.LoadScene("LevelSelector"); 
    }
    public void Toxic() {
        _home.Play(); Invoke("ToxicDelay", 1f);
    }
    public void Lava() {
        _home.Play(); Invoke("LavaDelay", 1f); }
    public void Ice() { _home.Play(); Invoke("IceDelay", 1f); 
    }
    void ToxicDelay() {
        SceneManager.LoadScene("Toxic 1"); }
    void LavaDelay() {  SceneManager.LoadScene("Lava 1"); 
    }
    void IceDelay() {
        SceneManager.LoadScene("Ice 1"); 
    }

    

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }



}
