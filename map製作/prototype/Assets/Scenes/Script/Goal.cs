using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("ひよこちゃんを助けたよ！！");

            SceneManager.LoadScene("OnGameClearScene", LoadSceneMode.Single);
        }
    }
}


	

	

	

