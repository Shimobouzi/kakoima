using UnityEngine;
using UnityEngine.SceneManagement;

public class KakoImaSceneManager : MonoBehaviour
{
    public static KakoImaSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void MainSceneLoad()
    {
        Time.timeScale = 1f;
        JsonController.instance.DeleteAllReplays();
        SceneManager.LoadScene("Main");
    }

    public void ReplayMainSceneLoad()
    {
        Time.timeScale = 1f;
        GameObject.Find("Player").GetComponent<Player>().SaveReplay();
        SceneManager.LoadScene("Main");
    }


}
