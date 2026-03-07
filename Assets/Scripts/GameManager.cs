using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState
{
    none,
    title,
    demo,
    gameplay,
    gameover,
    retry,
    stageclear,
    result,
    gameclear
}

public class GameManager : MonoBehaviour
{
    public static GameState gameState = GameState.none;
    public string nextScene;

    void Start()
    {
        gameState = GameState.gameplay;
    }

    static public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
