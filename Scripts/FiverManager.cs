using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//フィーバーゲージを制御
public class FiverManager : MonoBehaviour
{
    public Slider FiverGauge;
    public GameObject shuriken;
    public GameObject gun;
    bool Fiver;

    void Start()
    {
        gun.SetActive(false);
        FiverGauge.value = 0;
        Fiver = false;
    }

    void Update()
    {
        if(FiverGauge.value >= 1){
            Fiver = true;
            shuriken.SetActive(false);
            gun.SetActive(true);
        }
        else if(FiverGauge.value <= 0){
            Fiver = false;
            shuriken.SetActive(true);
            gun.SetActive(false);
        }

        if(Fiver){
            FiverGauge.value -= (float) 0.1 * Time.deltaTime;
        }
    }

    //ゲージを増やす
    public void Gaugeup(){
        if(Fiver){
            return;
        }
        FiverGauge.value += 0.1f;
    }

    //ゲージをリセットする
    public void Gaugereset(){
        if(Fiver){
            return;
        }
        FiverGauge.value = 0;
    }

    //フィーバー中か判定
    public bool IsFiver(){
        return Fiver;
    }
}
