using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
	//シュリケンを射出
    public void Shoot(Vector3 dir)
	{
		base.GetComponent<Rigidbody>().AddForce(dir);
	}

	private void OnCollisionEnter(Collision other)
	{
		Object.Destroy(base.gameObject, 0.2f);
	}

	//射出時にシュリケンを回転
	private void Update()
	{
		if (base.GetComponent<Rigidbody>().isKinematic)
		{
			base.transform.RotateAround(base.transform.position, Vector3.up, 0f);
			return;
		}
		base.transform.RotateAround(base.transform.position, Vector3.up, 1000f * Time.deltaTime);
	}
}