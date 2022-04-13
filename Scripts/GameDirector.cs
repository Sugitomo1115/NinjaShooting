using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
	public Text timerText;
	public Text scoreText;
	public GameObject finishText;
	public GameObject FiverManager;
	private float time = 40f;
	public static int point;
    
    private void Start()
	{
		GameDirector.point = 0;
		this.finishText.SetActive(false);
	}

	//ノーマル的に当てた場合
	public void HitNormalTarget()
	{
		if (this.FiverManager.GetComponent<FiverManager>().IsFiver())
		{
			GameDirector.point += 40;
		}
		else
		{
			GameDirector.point += 20;
		}
		this.FiverManager.GetComponent<FiverManager>().Gaugeup();
	}

	//マイナス的に当てた場合
	public void HitBadTarget()
	{
		GameDirector.point -= 10;
		this.FiverManager.GetComponent<FiverManager>().Gaugereset();
	}

	//ボーナス的に当てた場合
	public void HitBonusTarget()
	{
		if (this.FiverManager.GetComponent<FiverManager>().IsFiver())
		{
			GameDirector.point += 100;
		}
		else
		{
			GameDirector.point += 50;
		}
		this.FiverManager.GetComponent<FiverManager>().Gaugeup();
	}

	//スコアを取得
	public static int Getscore()
	{
		return GameDirector.point;
	}

	private void Update()
	{
		this.time -= Time.deltaTime;
		
		//タイムアップ時にスコアが保存されているハイスコアを超えていれば更新
		if (this.time <= 0f)
		{
			this.timerText.text = "0";
			if (PlayerPrefs.GetInt("HighScore") < GameDirector.point)
			{
				PlayerPrefs.SetInt("HighScore", GameDirector.point);
			}
			this.finishText.SetActive(true);
			base.Invoke("Result", 1.5f);
		}
		else
		{
			this.timerText.text = this.time.ToString("F0");
		}
		this.scoreText.text = GameDirector.point.ToString();
	}

	//リザルト画面に移行
	public void Result()
	{
		SceneManager.LoadScene("ResultScene");
	}
}
