using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private int gameOverRound = 5;

    private float vignetteValue = 0;
    private int _missCount = 0;
    private void Start()
    {
        vignetteValue = 1f / (float)gameOverRound;
        _missCount = KakoimaDB.Instance.getMissCount();
        ChangeGlobalVolume.Instance.SetVignette(vignetteValue * _missCount);

        if(_missCount > gameOverRound)
        {
            GameOverProcess();
        }
    }

    private void GameOverProcess()
    {
        KakoImaSceneManager.Instance.TitleSceneLoad();
    }

}
