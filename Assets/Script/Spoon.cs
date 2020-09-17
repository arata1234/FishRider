using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    //魚プレハブ
    public GameObject enemyPrefab;
    //Z座標の最小値
    public float zMinPosition = 0f;
    //Z座標の最大値
    public float zMaxPosition = 0f;

    [Header("雨の生成間隔")]
    [SerializeField, Range(0, 20f)] public float interval = 0.5f;
    [Header("X座標の最小値")]
    [SerializeField, Range(-100, 100)] private float xMinPosition = -17f;
    [Header("X座標の最大値")]
    [SerializeField, Range(0, 100)] private float xMaxPosition = 20f;
    [Header("Y座標の最小値")]
    [SerializeField, Range(-50, 100)] private float yMinPosition = 18f;
    [Header("Y座標の最大値")]
    [SerializeField, Range(-50, 100)] public float yMaxPosition = 17f;

    //敵生成時間間隔
    //経過時間
    private float time = 0f;

    public GameObject Spoon_Point;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        //interval = GetRandomTime();
       

        Spoon_Point = GameObject.Find("Spoon");
        enemyPrefab = GameObject.Find("sakana");
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;


        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyPrefab);
            //生成した魚の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            //interval = GetRandomTime();
        }
    }

    //ランダムな時間を生成する関数
    //private float GetRandomTime()
    //{
    //    //return Random.Range(minTime, maxTime);
    //}

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition + Spoon_Point.gameObject.transform.position.x, xMaxPosition + Spoon_Point.gameObject.transform.position.x);
        float y = Random.Range(yMinPosition + Spoon_Point.gameObject.transform.position.y, yMaxPosition + Spoon_Point.gameObject.transform.position.y);
        float z = Random.Range(zMinPosition + Spoon_Point.gameObject.transform.position.z, zMaxPosition + Spoon_Point.gameObject.transform.position.z);

        //Vector3型のPositionを返す
        return new Vector3(x, y=0, z);
    }
}
