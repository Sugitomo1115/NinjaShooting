using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    GameObject Target;

    //3種類の的の中でどの的を起こすか選ぶ
    public void ChoiceTarget()
    {
        int n = Random.Range(1,11);
        if(1 <= n && n <= 6)
        {
            this.Target = transform.GetChild(0).gameObject;
            Target.GetComponent<NormalTargetController>().Wake();
        }
        else if(7 <= n && n <=8)
        {
            this.Target = transform.GetChild(1).gameObject;
            Target.GetComponent<BonusTargetController>().Wake();
        }
        else if(9 <= n && n <=10)
        {
            this.Target = transform.GetChild(2).gameObject;
            Target.GetComponent<BadTargetController>().Wake();
        }
    }
}
