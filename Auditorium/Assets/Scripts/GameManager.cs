using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MusicBox[] _Box;
    public float chrono = 0f;
    public int nbBoxFull = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nbBoxFull = 0;
        foreach (var musicBox in _Box)
        {
           if (musicBox._bars[4].color == musicBox._onColor)
            {
                nbBoxFull++;
            }
        }
        if (nbBoxFull >=2 )
        {
            chrono += Time.deltaTime;
        }
        else
        {
            chrono = 0;
        }
        if (chrono >= 2)
        {
            Debug.Log("gagné !");
        }
    }
}
