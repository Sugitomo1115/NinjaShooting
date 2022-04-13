using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボーナス的の制御
public class BonusTargetController : MonoBehaviour
{
    GameObject director;
    bool hit_flag = false;
    Vector3 startPosition;
    public float movelength;
    public float speed;
    public GameObject HitEffect;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        startPosition = transform.localPosition;
    }

    void Update()
    {
        if(hit_flag)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 2.0f);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0), 2.0f);
        }

        float len = movelength * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(len, 0, 0);
    }

    //的を起こす
    public void Wake()
    {
        speed = Random.Range(0, 3);
        movelength = Random.Range(0, 4);
        hit_flag = true;
        Invoke("Miss", 3.0f);
    }

    //的に当てられなかった場合
    public void Miss()
    {
        hit_flag = false;
    }

    //的に当たった場合
    public void Hit()
    {
        Instantiate(HitEffect, this.transform.position + new Vector3(0,5.8f,0), Quaternion.Euler(0,180,0));
        GetComponent<AudioSource>().Play();
        director.GetComponent<GameDirector>().HitBonusTarget();
        hit_flag = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "shot"){
            Hit();
            Destroy(other.gameObject);
        }
    }
}
