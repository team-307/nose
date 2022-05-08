using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("ジャンプする速度")] public float jumpSpeed;
    [Header("高さ制限")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("あたまぶつけた判定")] public GroundCheck head;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool isHead = false;
    private bool rightTleftF = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
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
        
        //歩き
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



        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround(); 

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;
        float verticalKey = Input.GetAxis("Vertical");
        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f; 
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //New
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f; //New
            }
        }

        rb.velocity = new Vector2(xSpeed, ySpeed);

    }


}