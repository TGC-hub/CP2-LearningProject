using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryPointCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cherryEffect;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TingPoint")
        {
            gameManager.coinsCounter += 1;
            Destroy(Instantiate(cherryEffect, gameObject.transform.position, gameObject.transform.rotation), 0.5f);
            Destroy(gameObject);
        }
    }
}
