using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject boss;
    public GameObject Bonus;
    public Vector3 spawnValues;
    public Vector4 spawnVal;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public int bonusCount;
    public float spawnBonusWait;
    public float startBonusWait;
    public float bonusWaveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    private int score;
    private float incrementtime = 1f;
    private float incrementby = 1;
    private bool bossSpawned;
    private float counter = 0;
    private bool gameOver;
    private bool restart;

    void Start() {
        gameOver = false;
        restart = false;
        restartText.text = " ";
        gameOverText.text = "";
        score = 10;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnBonus());
        UpdateScore();
    }

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (!restart) {
            for (int i = 0; i < hazardCount; ++i) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver) {
                restartText.text = "Respawn (R)";
                restart = true;
            }
        }
    }

    IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(startWait);
        while (!restart) {
            for (int i = 0; i < bonusCount; ++i)
            {
                Vector4 spawnPosition = new Vector4(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); ;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Bonus, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnBonusWait);
            }
        }
    }

        public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "Game Over";
    }
    
    void Increment () {
        counter += incrementby;
    }
    
}
