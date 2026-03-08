using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string nextScene;
 
    void OnAttack(InputValue value)
    {
        SceneChange();
    }

    public void SceneChange()
    {
        ScoreManager.totalScore = 0;
        SceneManager.LoadScene(nextScene);
    }
}
