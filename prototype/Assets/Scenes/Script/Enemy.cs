using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "fire")
        {
            Debug.Log("炎にぶつかったよ！！");
            Destroy(this.gameObject);
        }
    }
}
