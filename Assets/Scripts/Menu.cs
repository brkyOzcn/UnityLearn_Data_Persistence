using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class Menu : MonoBehaviour
{
    [SerializeField] InputField inputField;

    void Start()
    {
        
    }

    public void StartTheGame()
    {
        DataHandler.instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {       
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    



}
