using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;

	private bool OnPause;

    private void Start()
    {
		OnPause = false;
    }

    void Update()
	{
		if (Input.GetButtonDown("Button_Y"))
		{
			if (pauseUIInstance == null)
			{
				pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
				Time.timeScale = 0f;
				OnPause = true;
			}
			else
			{
				Destroy(pauseUIInstance);
				Time.timeScale = 1f;
				OnPause = false;
			}
		}

        if (OnPause)
        {
			if (Input.GetButtonDown("Button_X"))
			{
				SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
			}
			if (Input.GetButtonDown("Button_B"))
			{
				SceneManager.LoadScene("StageSelectScene", LoadSceneMode.Single);
			}
		}
	}
}
