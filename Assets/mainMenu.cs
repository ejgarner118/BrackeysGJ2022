using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public  void playGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(2);
    }


    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        
    }
}
