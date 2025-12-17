using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private Scene scene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setGoalCount(1);
            if (scene == Scene.Main) KakoImaSceneManager.Instance.ReplayMainSceneLoad();
            else if (scene == Scene.Tutorial) KakoImaSceneManager.Instance.ReplayTutorialSceneLoad();
        }
        if (other.gameObject.tag == "ReplayPlayer" || other.gameObject.tag == "ReplayLoaderPlayer")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setMissCount(1);
            if (scene == Scene.Main) KakoImaSceneManager.Instance.ReplayMainSceneLoad();
            else if (scene == Scene.Tutorial) KakoImaSceneManager.Instance.ReplayTutorialSceneLoad();
        }
    }
}
