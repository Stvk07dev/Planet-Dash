using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag_nDrop : MonoBehaviour
{

    bool moveAllowed;
    Collider2D col;
   private GameMaster _master;
    private AudioSource _audioSource;
    [SerializeField] private AudioSource _death;

    [SerializeField] GameObject selection,death;


    void Start()
    {
       
        Debug.Log("Void Start");
        _master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        if (_master == null) Debug.LogError("Master Initialization");
        _audioSource = GetComponent<AudioSource>();
      
        col = GetComponent<Collider2D>();
    
    }

    
    void Update()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            if(touch.phase== TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPos);
                if (col == touchCollider)
                {
                    _audioSource.Play();
                    Instantiate(selection,transform.position,Quaternion.identity);
                    moveAllowed = true;
                }
            }

            if(touch.phase== TouchPhase.Moved)
            {
                if (moveAllowed == true)
                {
                    transform.position = new Vector2(touchPos.x,touchPos.y);
                }
            }

            if(touch.phase== TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Void")
        {
            Instantiate(death, transform.position, Quaternion.identity);
            _master.GameOver();
         _death.Play();
            Destroy(gameObject);
             
        }
    }

}
