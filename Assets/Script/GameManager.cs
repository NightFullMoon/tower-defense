using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject endUI;
    public Text endMessage;

    public static GameManager Instance ;

    private enemySpawner enemySpawnerObject;

     void Awake()
    {
        Instance = this;
        enemySpawnerObject = GetComponent<enemySpawner>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Win() {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }

    public void Failded() {
        endUI.SetActive(true);
        endMessage.text = "失 败";
        enemySpawnerObject.stop();
    }
}
