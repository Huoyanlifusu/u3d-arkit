using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class CoreLogic : MonoBehaviour
{
    public int health;
    public float defendTime;

    private float curDefendTime;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI defendTimeText;

    public GameObject winScreen;
    public GameObject loseScreen;

    public bool gameOver;

    private Camera cam;

    public static CoreLogic instance;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health:" + health;

        cam = Camera.main;

        curDefendTime = defendTime;


    }

    // Update is called once per frame
    void Update()
    {
        healthText.transform.rotation = Quaternion.LookRotation(healthText.transform.position - cam.transform.position);

        if (gameOver)
        {
            return;
        }
        defendTimeText.text = "Defend for " + Mathf.RoundToInt(curDefendTime) + "s";
        curDefendTime -= Time.deltaTime;

        if (curDefendTime <= 0.0f)
        {
            WinGame();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            GameOver();
        }
        
    }

    public void WinGame()
    {
        gameOver = true;
        winScreen.SetActive(true);
        EnemySpawner.instance.canSpawnEnemy = false;
    }

    public void GameOver()
    {
        gameOver = true;
        loseScreen.SetActive(true);
        EnemySpawner.instance.canSpawnEnemy = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
