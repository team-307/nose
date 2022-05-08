using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Button_B"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
}
