using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // リジッドボディを使うための宣言
    Rigidbody2D rbody;

    // LifeCount呼び出し
    [SerializeField] private LifeCount LifeCount;

    // 変数宣言
    public int p_life;                    // ライフ
    public bool isAlive;                 // 生きているかどうか

    public float speed = 5f;              // 移動する速度
    public float jumpP = 1000f;           // ジャンプ力

    public bool canHold;                  // オブジェクトを持てるかどうかをfireスクリプトに渡す

    private float time;                   // delay処理

    public bool isDamaged = false;        // ダメージフラグ

    private SpriteRenderer pRenderer;     // プレイヤーのレンダラー取得

    public GameObject bullet;
    Vector3 createPosition;



    void Start()
    {
        // リジッドボディ2Dをコンポーネントから取得して変数に入れる
        rbody = GetComponent<Rigidbody2D>();

        // 体力ゲージに反映
        LifeCount.SetLifeCount(p_life);

        isAlive = true;

        canHold = false;

        time = 1.0f;

        pRenderer = gameObject.GetComponent<SpriteRenderer>();

        this.gameObject.SetActive(true);

        //currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。

    }

    void Update()
    {
        time += Time.deltaTime;

        // ジャンプ
        if (time >= 1.0f) // 1秒以内の連打をスルー
        {
            // キーボード
            // もしスペースキーが押されて、上方向に速度がない時に
            if (Input.GetKeyDown(KeyCode.Space) && rbody.velocity.y == 0)
            {
                // リジッドボディに力を加える（上方向にジャンプ力をかける）
                rbody.AddForce(transform.up * jumpP);

                time = 0.0f; // 時間を初期化
            }

            // コントローラー
            if (Input.GetButtonDown("Button_A") && rbody.velocity.y == 0)
            {
                // リジッドボディに力を加える（上方向にジャンプ力をかける）
                rbody.AddForce(transform.up * jumpP);

                time = 0.0f; // 時間を初期化
            }
        }

        // 移動(キーボード)
        if (Input.GetKey(KeyCode.A)) rbody.velocity = new Vector2(-speed, rbody.velocity.y);
        if (Input.GetKey(KeyCode.D)) rbody.velocity = new Vector2(speed, rbody.velocity.y);


        // 移動(コントローラー)
        const float SPEED = 0.1f;

        float x = Input.GetAxis("Horizontal_L_Stick");
        float y = Input.GetAxis("Vertical_L_Stick");

        this.gameObject.transform.position += new Vector3(x * SPEED, 0, y * 0);

        // 点滅
        if (isDamaged) Blink();

        if (Input.GetMouseButtonDown(0))
        {
            createPosition = transform.position;
            createPosition.x += 1.0f; // プレイヤーのy座標 + 1の位置に弾を生成する

            Instantiate(bullet, createPosition, Quaternion.identity);
        }


    }

    public void Damage(int damage)
    {
        p_life -= damage;

        // ０より下の数値にならないようにする
        p_life = Mathf.Max(0, p_life);

        if (p_life >= 0)
        {
            LifeCount.SetLifeCount(p_life);
        }

        isDamaged = true;

        StartCoroutine("Wait");
    }

    // プレイヤー点滅
    public void Blink()
    {
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        pRenderer.color = new Color(1f, 1f, 1f, level); // 透明にする
    }

    IEnumerator Wait()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1);

        // １秒後ダメージフラグをfalseにする
        isDamaged = false;
        pRenderer.color = new Color(1f, 1f, 1f, 1f); // 元の色にもどす
    }

    // 敵(tyrannosaurus)と当たった時の処理
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tyrannosaurus")
        {
            //Debug.Log(p_life);
            Damage(1);


            if (p_life <= 0)
            {
                //Debug.Log("死んだ");
                isAlive = false;
                //Destroy(this.gameObject);

                this.gameObject.SetActive(false);

                // ゲームオーバーシーンへ
                SceneManager.LoadScene("OnGameoverScene", LoadSceneMode.Single);
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CarryObject")
        {
            canHold = true;
        }
        else
        {
            canHold = false;
        }
    }

}
