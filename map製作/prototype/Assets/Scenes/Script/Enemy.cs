using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Vector2 pos;
    public int num = 1;

    void Update()
    {

        pos = transform.position;

        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(transform.right * Time.deltaTime * 3 * num);

        if (pos.x > 85)
        {
            transform.localScale = new Vector3(+1, 1, 1);

            num = -1;
        }
        if (pos.x < 79)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            num = 1;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "fire")
        {
            Debug.Log("炎にぶつかったよ！！");
            Destroy(this.gameObject);
        }
    }
}
