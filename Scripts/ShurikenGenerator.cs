using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenGenerator : MonoBehaviour
{
    public GameObject ShurikenPrefab;
	public GameObject FiverManager;
	private float Shoot_Interval;
	private bool shoot_flag = true;
    
    private void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 direction = ray.direction;
			if (this.FiverManager.GetComponent<FiverManager>().IsFiver())
			{
				RaycastHit raycastHit;
				if (this.Shoot_Interval % 8f == 0f && Physics.Raycast(ray, out raycastHit))
				{
					string tag = raycastHit.collider.tag;
					if (tag != null)
					{
						if (!(tag == "NormalTarget"))
						{
							if (!(tag == "BonusTarget"))
							{
								if (tag == "BadTarget")
								{
									raycastHit.collider.gameObject.GetComponent<BadTargetController>().Hit();
								}
							}
							else
							{
								raycastHit.collider.gameObject.GetComponent<BonusTargetController>().Hit();
							}
						}
						else
						{
							raycastHit.collider.gameObject.GetComponent<NormalTargetController>().Hit();
						}
					}
				}
			}
			else if (this.Shoot_bool())
			{
				Object.Instantiate<GameObject>(this.ShurikenPrefab, base.transform).GetComponent<ShurikenController>().Shoot(direction.normalized * 4000f);
				base.GetComponent<AudioSource>().Play();
				this.shoot_flag = false;
				base.Invoke("Reload", 0.5f);
			}
		}
		this.Shoot_Interval += 1f;
	}

	//シュリケンを射出可能状態に
	private void Reload()
	{
		this.shoot_flag = true;
	}

	//シュリケンが射出可能か判定
	private bool Shoot_bool()
	{
		return this.shoot_flag;
	}
}
