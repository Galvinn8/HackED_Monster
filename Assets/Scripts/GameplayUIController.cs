using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //two ways
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
