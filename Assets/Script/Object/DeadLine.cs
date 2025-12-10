using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField]
    private float deadSpeed = 0.2f;

    private void Update()
    {
        this.GetComponent<Rigidbody>().linearVelocity = Vector3.up * deadSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setMissCount(1);
            KakoImaSceneManager.Instance.ReplayMainSceneLoad();
        }
    }
}
