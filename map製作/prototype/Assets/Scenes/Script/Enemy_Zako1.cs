using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    private Vector2 pos;
    public int num = 1;

    void Update()
    {

        pos = transform.position;

        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(transform.right * Time.deltaTime * 3 * num);

        if (pos.x > 27)
        {
            transform.localScale = new Vector3(+1, 1, 1);

            num = -1;
        }
        if (pos.x < 22)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            num = 1;
        }
    }


    //void FixedUpdate()
    //{
        //if (sr.isVisible || nonVisibleAct)
        //{
        //    int xVector = -1;
        //    if (rightTleftF)
        //    {
        //        xVector = 1;
        //        transform.localScale = new Vector3(-1, 1, 1);
        //    }
        //    else
        //    {
        //        transform.localScale = new Vector3(1, 1, 1);
        //    }
        //    rb.velocity = new Vector2(xVector * speed, -gravity);
        //}
        //else
        //{
        //    rb.Sleep();
        //}

        //if (sr.isVisible || nonVisibleAct)
        //{
        //    if (checkCollision.isOn)
        //    {
        //        rightTleftF = !rightTleftF;
        //    }
        //    int xVector = -1;
        //    if (rightTleftF)
        //    {
        //        xVector = 1;
        //        transform.localScale = new Vector3(-1, 1, 1);
        //    }
        //    else
        //    {
        //        transform.localScale = new Vector3(1, 1, 1);
        //    }
        //    rb.velocity = new Vector2(xVector * speed, -gravity);
        //}
    //}

}