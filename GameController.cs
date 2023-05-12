using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{


    private int saveScenes;
    private int sceneToContinue;
    private int sceneToContinue2;

    private GameObject pauseUI;

 
    public GameObject lv2;
    public GameObject lv3;
    public GameObject lv4;
    public GameObject lv5;

  

     void Start()
    {
       
        pauseUI = GameObject.Find("PauseUI");
        lv2 = GameObject.Find("LV2");
        lv3 = GameObject.Find("LV3");
        lv4 = GameObject.Find("LV4");
        lv5 = GameObject.Find("LV5");

        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 6)
        {
            pauseUI.SetActive(false);
        }


        

        
        
    }


     void Update()
    {
        sceneToContinue = PlayerPrefs.GetInt("SaveScene", saveScenes);

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            switch (sceneToContinue)
            {
                case 2: lv2.SetActive(false); break;
                case 3: lv2.SetActive(false);
                    lv3.SetActive(false);            
                    break;
                case 4:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    break;
                case 5:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    break;

                default: break;
            }
             
            
        }
    }

    public void PauseUI()
    {

        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;

    }


    public void CancelPause()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
    }

    public void LoadContinue()
    {
     
        if (sceneToContinue != 0)
        {

            SceneManager.LoadScene(sceneToContinue);
            Time.timeScale = 1.0f;

        }
        

    }
  
    public void LoadLv1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void LoadLv2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void LoadLv3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    public void LoadLv4()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }
    public void LoadLv5()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1.0f;
    }


    public void LoadMenu()
    {   
        if(SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 6)
        {
            saveScenes = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SaveScene", saveScenes);
           
        }
     
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void SeLectLecvel()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1.0f;

    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(8);
        Time.timeScale = 1.0f;
    }
    public void StartGame()
    {
        Invoke("NewGame", 1);

    }


    public void Exit()
    {
        Application.Quit();
    }


    public void LinkStore()
    {
        Application.OpenURL("https://thaogc.itch.io");
    }

}
