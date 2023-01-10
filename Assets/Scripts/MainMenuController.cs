using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
    {
        int selectedCharacter = // convert the string into an int, which can be used as the index to get the corresponding player in the character list
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); //get the name of the button pressed

        GameManager.instance.CharIndex = selectedCharacter;
        SceneManager.LoadScene("Gameplay");
    }
        
    
}
