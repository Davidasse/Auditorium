using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public MusicBox[] _Box;
    public float chrono = 0f;
    public int nbBoxFull = 0;

    public UnityEvent LevelSuccess = new UnityEvent();
    public UnityEvent EcranFin = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        //GameObject[] boxes = GameObject.FindGameObjectsWithTag("OuterZone");

        // en c# les tableau
    }

    IEnumerator fin()
    {
        yield return new WaitForSeconds(3);
        LevelSuccess.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        //On reinitialise le nbBoxFull a chaque debut de comptage pour toujours reprendre de zero
        nbBoxFull = 0;
        //on demarre la boucle
        foreach (var musicBox in _Box)
        {
           if (musicBox._bars[4].color == musicBox._onColor)
            {
                nbBoxFull++;
            }
        }
        if (nbBoxFull >= _Box.Length )
        {
            chrono += Time.deltaTime;
        }
        else
        {
            //s'il y a une decrementation de musicBox, on ré-init le chrono
            chrono = 0;
        }

        //Si le chrono atteint deux secondes, le joueur a gagné
        if (chrono >= 2)
        {
            //Debug.Log("gagné !");
            EcranFin.Invoke();
            StartCoroutine("fin");
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
