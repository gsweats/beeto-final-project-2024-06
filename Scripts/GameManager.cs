using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Levels
    public GameObject[] levels;
    public Transform levelsParent; 
    int currentLevelIndex = 0;
    GameObject currentSpawnedLevel;
   
    
    //Gui
    public GameObject inGameHudPanelGO;
    
    public GameObject titleScreenGO;
    public GameObject paddlePrefab;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public Transform paddleSpawnPoint;
    
    public GameObject gameOverScreen;
    public GameObject loseMessage;
    public GameObject winMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

   

}
