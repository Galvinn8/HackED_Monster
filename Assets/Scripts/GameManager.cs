using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   // other class now can access the object instance of the GameManager Class

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;

    public int CharIndex // a public function
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        //make sure only one instance is inside the game play
        if (instance == null)
        {
            
            instance = this;  //it is equal to the instance of this class, create a copy of the instance that is equal to this
            DontDestroyOnLoad(gameObject); // do not destroy the game object when loading a new scene
        }
        else
        {
            Destroy(gameObject); //destroy the dublicate game object
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnlevelFinishedLoading;  //when call the sceneload function, the method onlevelfinishedloading will be called automatically

    }

    private void OnDisable() // as soon as a new scene is loaded, it will call the onlevelfinishedloading function
    {
        SceneManager.sceneLoaded -= OnlevelFinishedLoading; // unsubscribe from the screne loaded

    }

    void OnlevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(characters[CharIndex]);
        }
    }

    }

