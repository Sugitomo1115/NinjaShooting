using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreNum;
	private int score;

	//スコアを取得し、UIに反映
    private void Start()
	{
		this.score = GameDirector.Getscore();
		this.scoreNum.text = this.score.ToString("F0");
	}
}
