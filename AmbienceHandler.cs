using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceHandler : MonoBehaviour
{
    [SerializeField] private bool lava=false,ice=false,toxic=false;
    [SerializeField] private AudioSource ambience;
    [SerializeField] private AudioSource ambience2;
    [SerializeField] private AudioSource ambience3;

    private void Start()
    {
        if (lava==true) { ambience2.Play(); }
        else if (ice==true) { ambience3.Play(); } 
        else if(toxic == true){ ambience.Play(); }
    }
}
