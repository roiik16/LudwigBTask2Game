using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int highestScore = 0;
    public static int currentScore = 0;

    public GameObject playermovement;

    bool gameHasEnded = false;

    public float restartDelay = 2f;


    public GameObject completelevelUI;

    private void Start()
    {
        StartCoroutine(Howto());
    }

    public void CompleteLevel()
    {
        completelevelUI.SetActive(true);
    }


	// Update is called once per frame
	public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
	}
    
    public static void SetHighScore(int number)
    {
        if (number > highestScore) highestScore = number;
    }


    void Restart()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        GameManager.currentScore = (int)player.position.z;
        GameManager.SetHighScore((int)player.position.z);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void HideGUI()
    {
        playermovement.SetActive(false);
    }

    IEnumerator Howto()
    {
            yield return new WaitForSeconds (5.5f);
            HideGUI();
    }
}
