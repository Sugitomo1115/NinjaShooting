using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject ShotEffect;

    //銃のエフェクト制御
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ShotEffect.SetActive(true);
        }
        else
        {
            ShotEffect.SetActive(false);
        }
    }
}
