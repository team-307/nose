using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    // ライフゲージプレハブ
    [SerializeField] private GameObject lifeObj;

    // ライフゲージ全削除＆HP分作成
    public void SetLifeCount(int life)
    {
        // 体力を一旦削除
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        // 現在の体力数分のライフゲージを作成
        for(int i = 0; i < life; i++)
        {
            Instantiate(lifeObj, transform);
        }
    }    
}
