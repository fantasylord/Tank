using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 类成员
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;//子弹旋转角度
    private float timeValue;
    private float defendTimeValue;
    private bool isDefend=true;
    private bool isFire;
    public float h;
     public float v;
    public ButtonEnum buttonNum=ButtonEnum.value;
    #endregion
    #region 引用 
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//坦克四个方向图
    public GameObject bullectPrefab;//子弹
    public GameObject explosionPrefab;//爆炸特效
    public GameObject defendEffectPrefab;
    public AudioSource moveAudio;
    public AudioClip[] audioSource;

    #endregion
    private void Awake()//0 8 16 24
    {
        sr = GetComponent<SpriteRenderer>();//让tanksprite获取预置好的图
    }
    // Use this for initialization
    void Start()
    {
        timeValue = 0.5f;
        defendTimeValue = 3.0f;
        Invoke("MessageUI", 0.5f);
    }
    public void MessageUI()
    {
        print("消息发送Game");
        ButtonControlInstance.Instance.SetPlayer(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDefend)
        {
            defendEffectPrefab.SetActive(true);
            if((defendTimeValue -= Time.deltaTime)<=0)
            {
                isDefend = false;
                defendEffectPrefab.SetActive(false);
            }
              
           

        }
        if (h == 0 && v == 0)
        {
            moveAudio.clip = audioSource[0];
            
           
        }
        else
        {
            moveAudio.clip = audioSource[1];

        }
        if (!moveAudio.isPlaying)
            moveAudio.Play();
        //      float h = Input.GetAxisRaw("Horizontal");
        //      transform.Translate(Vector3.right * h*moveSpeed*Time.deltaTime,Space.World);
        //      float v = Input.GetAxisRaw("Vertical");
        //      transform.Translate(Vector3.up * v*moveSpeed*Time.deltaTime,Space.World);
        //      if(h<0)
        //      {
        //          sr.sprite = tankSprite[3];
        //      }
        //else if(h>0)
        //      {
        //          sr.sprite = tankSprite[1];
        //      }
        //      if (v < 0)
        //      {
        //          sr.sprite = tankSprite[2];
        //      }
        //      else if (v > 0)
        //      {
        //          sr.sprite = tankSprite[0];
        //      }
    }
    private void FixedUpdate()//update之后 固定物理帧  （update 更新频率会变动）
    {
        if (PlayerManager.Instance.isDefeat)
            return;
  
        if (buttonNum == ButtonEnum.value)
            MoveTank();
        else    MovePhoneTank();

        //攻击间隔
        if (timeValue >= 0.4f)
        {
            Attack();
            isFire = true;

        }
        else
        {
            timeValue += Time.deltaTime;
        }

    }
    private void Death()
    {
        if(!isDefend)
        { Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
         
        }
    }
    private void OnDestroy()
    {
        PlayerManager.Instance.Recover();
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeValue = 0;
            buttonNum = ButtonEnum.value;
        }
        if (isFire &&buttonNum == ButtonEnum.hit)
        {
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeValue = 0;
            buttonNum = ButtonEnum.value;
            isFire = false;

        }
    }
    private void MoveTank()
    {
        h = Input.GetAxisRaw("Horizontal");
       v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)//下
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)//上
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
        if (h != 0)
        {

            return;
        }
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)//左
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)//右
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void MovePhoneTank()
    {
        switch (buttonNum)
        {
            case ButtonEnum.up:
                h = 0; v = 1;//上
                break;
            case ButtonEnum.down:
                h = 0; v = -1;//下
                break;
            case ButtonEnum.left:
                h = -1; v = 0;//右
                break;
            case ButtonEnum.right:
                h = 1; v = 0;
                break;
            case ButtonEnum.hit:
                Attack();
                break;
            case ButtonEnum.value:
                h = 1; v = 0;
                break;
            default:
                break;
        }

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)//下
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)//上
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
        if (h != 0)
        {

            return;
        }
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)//左
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)//右
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }
    }
    public enum ButtonEnum
    {
         value,up=1,right,down,left,hit
    }
    public void  MoveNeedButtonNum(ButtonEnum buttonfun)
    {
        buttonNum = buttonfun;
        //                h = 0; v = -1;//下
        //                break;
        //            case 6:
        //                h = 1; v = 0;//右
        //                break;
        //            case 8:
        //                h = 0; v = 1;//上
        //                break;
        //            default:
        //                h = 0; v = 0;
      
    }
}
