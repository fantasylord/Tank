using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int lifeMaxValue = 3;
    public int lifeValue;
    public int playerScore = 0;
    public bool isDead = false;
    public bool isHeartDead = false;
    public bool isDefeat = false;//是否结束
    private static  PlayerManager instance;
    public Text playerScoreText;
    public Text playerLifeText;
    public GameObject img_GameOver;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public GameObject born;

    private PlayerManager()
    {
        lifeValue = lifeMaxValue;
    }
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefeat)
        {
            img_GameOver.SetActive(true);
            return;
        }
        playerScoreText.text = playerScore+"";
         playerLifeText.text = lifeValue+"";
        if (isDead )
        {
            Recover();
        }
        if (isHeartDead)
        { isDefeat = true; Invoke("ReturnToMainMenu", 2f); }//游戏失败返回主界面


        }
    public void RefreshScore(string level)
    {
        playerScore += int.Parse(level+"")*2;
    }
    public void Recover()
    {
        if (lifeValue <= 0)
        {
            isDefeat = true;
         
            //GameOver
        }
        else
        {
            lifeValue--;
             Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity).GetComponent<Born>().IsGetPlayer = true;
      
            isDead = false;
        }
    }
    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
