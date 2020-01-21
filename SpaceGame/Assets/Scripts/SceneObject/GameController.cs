using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject MainMenu;
    [Space]
    public GameObject GameInterface;
    public Text TextScore;
    public Image ImageHealth;
    public Image ImageShield;
    [Space]
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    private int score;
    private bool isStarted = false;
    private static GameController instance;
    private GameObject player;
    private GameObject spawnObjects;
    private Vector3 startPlayerPosition;

    private void Start()
    {
        spawnObjects = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
        startPlayerPosition = player.transform.position;
        Time.timeScale = isStarted ? 1 : 0;
        AudioListener.volume = isStarted ? 1 : 0;
    }

    private void Update()
    {
        if (isStarted && Input.GetKeyDown("escape"))
        {
            GamePause();
        }
    }

    public static GameController isInstance()
    {
        if (!instance)
        {
            instance = GameObject
                .FindGameObjectWithTag("GameController")
                .GetComponent<GameController>();
        }
        return instance;
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        ImageHealth.fillAmount = (float)health / maxHealth;
    }

    public void UpdateShield(int shield, int maxShield)
    {
        ImageShield.fillAmount = (float)shield / maxShield;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        TextScore.text = "Score: " + this.score;
    }

    public bool GetIsStarted()
    {
        return isStarted;
    }

    public void StartTheGame()
    {
        gameRestate(MainMenu);
    }

    public void GamePause()
    {
        gameRestate(PauseMenu);
    }

    public void GameOver()
    {
        gameRestate(GameOverMenu);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void RestartTheGame()
    {
        gameRestate(GameOverMenu);
        PauseMenu.SetActive(false);
        TextScore.text = "Score: 0";
        spawnObjects.GetComponent<SpawnShips>().DroppingWave();
        spawnObjects.GetComponent<SpawnAsteroids>().DroppingWave();
        destroyObjects(GameObject.FindGameObjectsWithTag("Asteroid"));
        destroyObjects(GameObject.FindGameObjectsWithTag("OShip"));
        destroyObjects(GameObject.FindGameObjectsWithTag("Consumable"));
        destroyObjects(GameObject.FindGameObjectsWithTag("ChargeOpponents"));
        destroyObjects(GameObject.FindGameObjectsWithTag("ChargePlayer"));
        destroyObjects(GameObject.FindGameObjectsWithTag("Explosion"));
        player.transform.position = startPlayerPosition;
        player.transform.rotation = Quaternion.identity;
        player.SetActive(true);
        PlayerLife playerLife = player.GetComponent<PlayerLife>();
        playerLife.Health = playerLife.MaxHealth;
        UpdateHealth(playerLife.Health, playerLife.MaxHealth);
    }

    private void gameRestate(GameObject menu)
    {
        menu.SetActive(isStarted);
        Cursor.visible = isStarted;
        Cursor.lockState = isStarted ? CursorLockMode.None : CursorLockMode.Locked;
        isStarted = !isStarted;
        GameInterface.SetActive(isStarted);
        Time.timeScale = isStarted ? 1 : 0;
        AudioListener.volume = isStarted ? 1 : 0;
    }

    private void destroyObjects(GameObject[] objects)
    {
        foreach (GameObject instance in objects)
        {
            Destroy(instance);
        }
    }
}
