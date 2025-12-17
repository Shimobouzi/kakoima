using UnityEngine;
using UnityEngine.SceneManagement;

public class KakoImaSceneManager : MonoBehaviour
{
    public static KakoImaSceneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void TitleSceneLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void MainSceneLoad()
    {
        Time.timeScale = 1f;
        JsonController.instance.DeleteAllReplays();
        KakoimaDB.Instance.ResetCount();
        SceneManager.LoadScene("Main");
    }

    public void ReplayMainSceneLoad()
    {
        Time.timeScale = 1f;
        GameObject.Find("Player").GetComponent<Player>().SaveReplay();
        SceneManager.LoadScene("Main");
    }

    public void TutorialSceneLoad()
    {
        Time.timeScale = 1f;
        JsonController.instance.DeleteAllReplays();
        KakoimaDB.Instance.ResetCount();
        SceneManager.LoadScene("Tutorial");
    }

    public void ReplayTutorialSceneLoad()
    {
        Time.timeScale = 1f;
        GameObject.Find("Player").GetComponent<Player>().SaveReplay();
        SceneManager.LoadScene("Tutorial");
    }


}
