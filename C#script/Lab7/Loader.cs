using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    Manager manager=new Manager();
    
    //public Button start;
    //public Animator animator;
    //public GameObject loadImage;
    //public GameObject eventsystem;
    void Start()
    {
        manager.Animator = GameObject.Find("Image").GetComponent<Animator>();
        manager.Start = GameObject.Find("Start").GetComponent<Button>();
        manager.LoadImage = this.gameObject;
        manager.EventSystem = GameObject.Find("EventSystem");
        GameObject.DontDestroyOnLoad(manager.EventSystem);
        GameObject.DontDestroyOnLoad(manager.LoadImage);
        manager.Start.onClick.AddListener(LoadScene);
    }

    void Update()
    {
        
    }

    private void LoadScene()
    {
        StartCoroutine(LoadScene(1));
        StartCoroutine(SetFalse());
    }

    IEnumerator LoadScene(int sceneNum)
    {
        manager.Animator.SetBool("Loading", true);
        manager.Animator.SetBool("Loaded", false);

        yield return new WaitForSeconds(1.2f);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneNum);
        async.completed += LoadedScene;
        
    }

    private void LoadedScene(AsyncOperation obj)
    {
        manager.Animator.SetBool("Loading", false);
        manager.Animator.SetBool("Loaded", true);
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(1.6f);
        manager.LoadImage.SetActive(false);
    }
}
