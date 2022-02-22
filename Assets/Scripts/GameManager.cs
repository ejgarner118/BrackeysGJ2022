using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1.5f;
    bool isPaused = false;                  //Is Game paused
    public GameObject completeLevelUI;      //Between level transition
    bool gameHasEnded = false;              //Player hits an object



    //What to do when completing the level
    public void CompleteLevel()
    {
        //Display UI element between levels
        completeLevelUI.SetActive(true);

    }

    //What to do when hitting an obstacle
    public void hitObstacle()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOVer!!");
            Invoke("Restart", restartDelay);
        }

    }

    //What to do when falling off
    public void fallOff()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOVer!!");
            Invoke("Restart", restartDelay);
        }

    }

    //Restart the Level
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Used to pause/unpause
    private void Update()
    {
        //Pause/unpause the game
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = !isPaused;

            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
     }
}
