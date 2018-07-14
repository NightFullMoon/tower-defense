using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject endUI;
    public Text endMessage;

    public static GameManager Instance;

    private enemySpawner enemySpawnerObject;

    void Awake()
    {
        Instance = this;
        enemySpawnerObject = GetComponent<enemySpawner>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }

    public void Failded()
    {
        endUI.SetActive(true);
        endMessage.text = "失 败";
        enemySpawnerObject.stop();
    }

    //点击了重试按钮的时候
    public void OnClickRetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //点击了菜单按钮的时候
    public void OnClickMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
}
