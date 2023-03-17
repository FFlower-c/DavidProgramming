using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager
{
    private Button start;
    private Animator animator;
    private GameObject loadImage;
    private GameObject eventsystem;


    public Button Start
    {
        get { return start; }
        set { start = value; }
    }

    public Animator Animator
    {
        get { return animator; }
        set { animator = value; }
    }
    public GameObject LoadImage
    {
        get { return loadImage; }
        set { loadImage = value; }
    }
    public GameObject EventSystem
    {
        get { return eventsystem; }
        set { eventsystem = value; }
    }

}
