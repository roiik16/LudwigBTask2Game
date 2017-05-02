using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //public static int highestScore;

    bool gameHasEnded = false;

    public float restartDelay = 2f;


    public GameObject completelevelUI;



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
    

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
