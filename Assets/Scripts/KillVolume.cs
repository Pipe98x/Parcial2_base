using UnityEngine;
using UnityEngine.UI;

public class KillVolume : MonoBehaviour
{
    [SerializeField]
    private Shelter[] shelters;
    [SerializeField]
    private GameObject gameOver;

    public void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0F;
        }

        Destroy(collision.gameObject);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0F;
    }
}