using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public GameObject d_target;


    //　ゲームオーバー時に表示するUIのプレハブ
    [SerializeField] private GameObject GmeoverUIPrefab;
    //　ゲームオーバーUIのインスタンス
    private GameObject GameoverUIInstance;

    private bool OnGameover;

    private bool isAlive;

    // プレイヤーの体力取得
    GameObject bird;
    Player p;

    private void Start()
    {
        bird = GameObject.Find("Player");
        p = bird.GetComponent<Player>();

        OnGameover = false;
    }

    void Update()
    {
        if (OnGameover)
        {
            // ステージリスタート
            if (Input.GetButtonDown("Button_X"))
            {
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }
        }
    }


    public void SetGameover()
    {
        
    }
}


//    public void CheckIsExists()
//    {
//        if (d_target)
//        {

//        }
//        else
//        {
//            isAlive = false;
//            //Debug.Log("消去");
//        }
//    }
//}
