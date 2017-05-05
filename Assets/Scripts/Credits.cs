using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text bestScore;
    public Text currentScore;

    private void Start()
    {
        bestScore.text = "Best : " + GameManager.highestScore.ToString();
        currentScore.text = "Current : " + GameManager.currentScore.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Dodge");
    }
}
