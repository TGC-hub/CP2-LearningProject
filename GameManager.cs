using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int coinsCounter = 0;
    public GameObject playerGameObject;
    private PlayerController player;
    public GameObject deathPlayerPrefab;
    public Text coinText;
    public Text coinDeath;

    public GameObject deathUI;
  
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        deathUI = GameObject.Find("DeathUI");
        deathUI.SetActive(false);
    }

    void Update()
    {
        coinText.text = "x" + coinsCounter.ToString();
        coinDeath.text = "Your Cherry : " + coinsCounter.ToString();
        if (player.deathState == true){
            player.gameObject.SetActive(false);
            GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
            deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
            player.deathState = false;
            deathUI.SetActive(true);
        }

        
        if(player.isNextScenes == true)
        {
            if(SceneManager.GetActiveScene().buildIndex < 5)
            {
                Invoke("NextScenes", 1);
                
            }else if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(7);
                
               
            }
          
           
        }
       
    }

    private void NextScenes()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = sceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Time.timeScale = 1;
        }

    }
    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        
   
    }
}
