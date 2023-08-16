using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public player p;
    public bool Gamestate = false;
    public GameObject Ball;
    public float setSpawnTime = 10f;
    public float timer =0f;
    public GameObject resetButton;
    public TextMeshProUGUI HealthShown;

    void Start()
    {
        Gamestate = false;
        Time.timeScale = 0;
        resetButton.SetActive(true);
        p.Health=p.startHealth;
    }

    public void clickToStart(){
        Gamestate= true;
        Time.timeScale = 1;
        resetButton.SetActive(false);
        p.Health=p.startHealth;
    }
    void ShowResetButton(){
        resetButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Gamestate && setSpawnTime<=timer){
            timer =0f;
            float randomX = Random.Range(-2, 2);
    
             Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            Instantiate(Ball, spawnPosition, Quaternion.identity);
        }
        if(Gamestate==false){
            ShowResetButton();
        }

        HealthShown.text = "Health = "+p.Health;
    }
}
