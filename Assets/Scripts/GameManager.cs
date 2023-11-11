using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text scoreText;

    public bool isGameOver = false;
    private float timeToRespawn = 2.0f;
    private float timeToReloadScene = 3.0f;

    private int playerScore = 0;

    float level = 3;

    private void Start()
    {
        scoreText.text = playerScore.ToString();
    }


    public void IncreaseScore(int score)
    {
        playerScore += score;
        scoreText.SetText(playerScore.ToString());
    }
    public void PlayerDied()
    {
        level--;
        isGameOver = true;
        IncreaseScore(-30);
        if (level <= 0)
        {
            Invoke(nameof(GameOver), timeToReloadScene);
        }
        else
        {
            Invoke(nameof(RespawnPlayer), timeToRespawn);
        }

    }

    private void RespawnPlayer()
    {
        isGameOver = false;
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), timeToRespawn + 1);
    }

    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
