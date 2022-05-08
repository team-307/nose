using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float f_speed = 0.1f;    // fireの速度

    public float f_moveSpeed = 0.3f;  // fireが持たれてるときの移動速度

    public GameObject target;       // 追従する対象を決める変数

    public GameObject enemy;        // エネミー判定

    private bool isHolded;          // fireが持たれているかどうか
    private bool isthrown;          // fireが投げられているかどうか

    public CircleCollider2D fire_col; // fireのコライダー

    GameObject bird;
    Player p;

    private void Start()
    {
        bird = GameObject.Find("Player");
        p = bird.GetComponent<Player>();

        isHolded = false;
        isthrown = false;
    }


    void Update()
    {
        // つかむ処理(マウス)
        if ((p.canHold)==true && (Input.GetMouseButton(0))) // プレイヤーが炎をつかめる範囲いて、左クリックを押している間
        {
            this.transform.position = new Vector2(target.transform.position.x + 3.0f, target.transform.position.y);

            isHolded = true;
        }
        // つかむ処理(コントローラー)
        if ((p.canHold) == true && (Input.GetAxis("Trigger_R2") > 0) && (Input.GetAxis("Trigger_L2") > 0)) // プレイヤーが炎をつかめる範囲いて、L2R2を押している間
        {
            this.transform.position = new Vector2(target.transform.position.x +3.0f, target.transform.position.y);

            isHolded = true;
        }

        // 持ちながら炎を動かす(コントローラー)

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 inputvec = new Vector2(x,-y);
        inputvec.Normalize();
       
        if (isHolded == true && ((Mathf.Abs(x)> 0.0f)|| (Mathf.Abs(y) > 0.0f)))
        {
            Vector2 pos = bird.transform.transform.position;
            this.transform.position = pos + inputvec * 3.0f;
        }

        // 投げる処理(マウス)
        if ((isHolded == true) && (Input.GetMouseButtonUp(0))) // fireが持たれていて、左クリックが離されたとき
            isthrown = true;
        // 投げる処理(コントローラー)
        if ((isHolded == true) && (Input.GetAxis("Trigger_R2") == 0) && (Input.GetAxis("Trigger_L2") == 0)) // fireが持たれていて、R2が離されたとき
        {
            isthrown = true;
            fire_col.enabled = true;
        }

        if (isthrown == true) LauncherShot();   
    }

    private void LauncherShot()
    {
        // 弾を発射する場所を取得
        Vector2 fPos = this.transform.position;

        this.transform.position = new Vector2(f_speed + fPos.x, fPos.y);

        isHolded = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "floor") // 床に落ちたらfalseにする
        //    isthrown = false;

        if (collision.gameObject.tag == "enemy") // エネミーに当たったら消す
         {
                Destroy(this.gameObject);
                //Debug.Log("炎にぶつかったよ！！");
         }
    }

    

}
