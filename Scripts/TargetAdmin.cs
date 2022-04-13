using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAdmin : MonoBehaviour
{
    public GameObject Targets1;
	public GameObject Targets2;
	public GameObject Targets3;
	public GameObject Targets4;
	public GameObject Targets5;
	public GameObject Targets6;
	private List<GameObject> Targetlist = new List<GameObject>();
	private GameObject Target;
	public float recovertimer;
	private float timer = 1f;
	private float counter;

	//すべての位置の的をリストに追加
    private void Start()
	{
		this.Targetlist.Add(this.Targets1);
		this.Targetlist.Add(this.Targets2);
		this.Targetlist.Add(this.Targets3);
		this.Targetlist.Add(this.Targets4);
		this.Targetlist.Add(this.Targets5);
		this.Targetlist.Add(this.Targets6);
	}

	private void Update()
	{
		this.timer -= Time.deltaTime;
		if (this.timer <= 0f)
		{
			this.timer = 1f;
			this.Selectpos();
		}
	}

	//リストからどの位置の的を起こすか選ぶ
	private void Selectpos()
	{
		int index = Random.Range(0, this.Targetlist.Count);
		GameObject gameObject = this.Targetlist[index];
		gameObject.GetComponent<TargetController>().ChoiceTarget();
		this.Targetlist.Remove(gameObject);	//選んだ的をリストから削除
		base.StartCoroutine(this.RecoverFlag(gameObject));
	}

	//削除された的を再度リストに追加
	private IEnumerator RecoverFlag(GameObject wakedtarget)
	{
		this.counter = this.recovertimer;
		while (this.counter > 0f)
		{
			yield return new WaitForSeconds(1f);
			this.counter -= 1f;
		}
		this.Targetlist.Add(wakedtarget);
		yield break;
	}
}
