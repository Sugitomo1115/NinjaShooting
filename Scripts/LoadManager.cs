using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Text timerText;
	private float time = 3.0f;

	//スタートまでのカウントダウンを制御
    private void Update()
	{
		this.time -= Time.deltaTime;
		if (this.time <= 0f)
		{
			SceneManager.LoadScene("GameScene");
		}
		this.timerText.text = this.time.ToString("F0");
	}
}
