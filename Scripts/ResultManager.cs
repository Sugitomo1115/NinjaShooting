using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
	public Text scoreNum;
	public Text HighScoreNum;
	private int score;

    private void Start()
	{
		this.score = GameDirector.Getscore();
		this.scoreNum.text = this.score.ToString("F0");
		this.HighScoreNum.text = PlayerPrefs.GetInt("HighScore").ToString("F0");
	}

	//ゲームをリトライし、カウントダウン画面に移行
	public void Retry()
	{
		SceneManager.LoadScene("LoadScene");
	}

	//タイトル画面に移行
	public void Title()
	{
		SceneManager.LoadScene("TitleScene");
	}
}
