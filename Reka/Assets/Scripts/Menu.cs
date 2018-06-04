﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Menu : MonoBehaviour
{

    public Canvas Manual_window;
    public Canvas Transmission_window;

    private Canvas Menu_window;

    void Start()
    {
        Menu_window = (Canvas)GetComponent<Canvas>();

        Transmission_window.GetComponent<Canvas>().enabled = false;
        Manual_window.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    { }
    public void clicked_transmisssion()
    {
        Menu_window.enabled = false;
        Transmission_window.enabled = true;
    }

    public void clicked_manual()
    {
        Menu_window.enabled = false;
        Manual_window.enabled = true;
    }

    public void clicked_exit()
    {
        Application.Quit();
    }
    
    public void clicked_return()
    {
        Transmission_window.enabled = false;
        Manual_window.enabled = false;
        Menu_window.enabled = true;
    }
            

}