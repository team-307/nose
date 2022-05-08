using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Button_B"))
        {
            SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
        }
    }
}