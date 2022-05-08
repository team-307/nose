using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Button_X"))
        {
            SceneManager.LoadScene("StageSelectScene", LoadSceneMode.Single);
        }
    }
}
