using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    //Levels
    public GameObject[] levels;
    public Transform levelsParent;
    int currentLevelIndex = 0;
    GameObject currentSpawnedLevel;


    //Ball movement
    public float minY = -5.5f;
     public float maxVelocity = 10f;
    public float minVelocity = 10f;
    //Lives
    int ballLives = 5;

    //Ball body
    Rigidbody2D rb;
    //Gui
    public GameObject inGameHud;
    public TextMeshProUGUI ballsLeftText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject loseMessage;
    public GameObject winMessage;
    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    public Transform ballSpawn;
    int tilesPerLevel = 36;
    int tilesKilled = 0;

    public Transform paddleSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
    }

    // Update is called once per frame
    void Update()
    {
       //Set velocity and remove life when ball hits bottom
        if (transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector2.down * 10f;
            removeBallLife();

        }

        //Max velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
        if(rb.velocity.magnitude > minVelocity)
        {

        }
        if (Input.GetKey(KeyCode.Space))
        {
            ballLives++;

        }

    }

    //Make it so player can win/lose


    //Remove amount of ball lives
    public void removeBallLife()
    {
        ballLives--;

        if (ballLives < 0)
        {
            gameOver(false);
            Destroy(gameObject);

        }
       else
        {
            ballsLeftText.text = "Balls Remaining " + ballLives;
        }
    }

    public void gameOver(bool didPlayerWin)
    {
        //gameOverScreenGO.SetAcive(true)

        if (didPlayerWin)
        {
            //Show victory message
            winMessage.SetActive(true);
            ballPrefab.SetActive(false);
            paddlePrefab.SetActive(false);
            currentSpawnedLevel.SetActive(false);


            Debug.Log("You Won");
        }
        else
        {
            //show lose message
            loseMessage.SetActive(true);
            //Hide everything
            loseMessage.SetActive(true);
            ballPrefab.SetActive(false);
            paddlePrefab.SetActive(false);
            currentSpawnedLevel.SetActive(false);

            Debug.Log("You Lost");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            Tile thisTileScript = collision.gameObject.GetComponent<Tile>();
            thisTileScript.tileHit();

        }
    }


    public void startGameButtonPushed()
    {
        inGameHud.SetActive(true);
        titleScreen.SetActive(false);
        ballPrefab.SetActive(true);
        paddlePrefab.SetActive(true);
        currentSpawnedLevel = Instantiate(levels[currentLevelIndex], levelsParent);

    }

    public void spawnNextLevel()
    {
        resetTileKills();
        //Increment next level....
        currentLevelIndex++;

        if (currentLevelIndex > 2)
        {
            Debug.Log("Need Victory Screen");
            gameOver(true);
        }
        else
        {
            //Spawn next level
            currentSpawnedLevel = Instantiate(levels[currentLevelIndex], levelsParent);

            //Move the player
            transform.position = ballSpawn.position;

        }

    }

    public void resetTileKills()
    {
        tilesKilled = 0;
    }
    public void incrementTilesKill()
    {
        tilesKilled++;

        if(tilesKilled == tilesPerLevel)
        {
            //Advanced level
            spawnNextLevel();
        }
    }

    public void spawnPaddle()
    {
        Instantiate(paddlePrefab, paddleSpawnPoint.position, Quaternion.identity);
    }
    public void spawnBall()
    {
        Instantiate(ballPrefab, ballSpawn.position, Quaternion.identity);
    }
}
