using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Button_X"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
}
