using UnityEngine;
using UnityEngine.SceneManagement;

public class KakoImaSceneManager : MonoBehaviour
{
    public static KakoImaSceneManager instance;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        instance = this;
    }

    public void MainSceneLoad()
    {
        Time.timeScale = 1f;
        player.SaveReplay();
        SceneManager.LoadScene("Main");

    }
}
