using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Option : MonoBehaviour {

    public GameObject Pos1;
    public GameObject Pos2;
    public enum Chioce
    {
        chioceValue=0,chiocePos1, chiocePos2,sureClick
    }
    private int chioce = 1;
    // Use this for initialization
    void Start () {
        Invoke("MessageUI", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
        {
            chioce = 2;
            transform.position=(Pos2.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            chioce = 1;
            transform.position=(Pos1.transform.position);
        }
       if(chioce ==1&& Input.GetKeyDown(KeyCode.J)){
            SceneManager.LoadScene(1);
        }
	}
    public void MessageUI()
    {
        print("消息发送Main");
        ButtonControlInstance.Instance.SetStart(this);
    }
    public void ChooseOption(Chioce _chioce)
    {
        switch (_chioce)
        {
            case Chioce.chiocePos1:
                chioce = 1;
                transform.position = (Pos1.transform.position);
                break;
            case Chioce.chiocePos2:
                chioce = 2;
                transform.position = (Pos2.transform.position);
                break;
            case Chioce.sureClick:
                if (chioce == 1)
                {
                    SceneManager.LoadScene(1);
                }
                break;
            default:
                break;
        }
    }
}
