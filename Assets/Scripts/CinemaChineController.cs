using UnityEngine;
using UnityEngine.Playables;

public class CinemaChineController : MonoBehaviour
{
    PlayableDirector playableDirector;
    public PlayableAsset gameResult;
    public PlayableAsset gameRetry;
    bool playing;


    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playing && GameManager.gameState == GameState.result)
        {
            playableDirector.enabled = true;
            playableDirector.Stop();
            playableDirector.playableAsset = gameResult;
            playableDirector.Play();
            playing = true;
        }
        if (!playing && GameManager.gameState == GameState.retry)
        {
            playableDirector.enabled = true;
            playableDirector.Stop();
            playableDirector.playableAsset = gameRetry;
            playableDirector.Play();
            playing = true;
        }
    }
}
