using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region 类成员
    public float moveSpeed = 1.5f;
    private Vector3 bullectEulerAngles;//子弹旋转角度
    private int level = 1;
    private float timeValue;//子弹间隔
    private float changeDirectionTimeValue;//自动转向时间
    private float defendTimeValue;//无敌时间
    private bool isDefend = false;//是否启用无敌
    private int[] changeRandoms = { 2, 4, 8, 6 ,2,2,2,4,6,5};
    float h = 0f;
    float v = 0f;
    #endregion
    #region 引用 
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//坦克四个方向图
    public GameObject bullectPrefab;//子弹
    public GameObject explosionPrefab;//爆炸特效
    public GameObject defendEffectPrefab;
 

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }
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
        changeDirectionTimeValue = 4.0f;
        h = 0; v = -1;//下
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefend)
        {
            defendEffectPrefab.SetActive(true);
            if ((defendTimeValue -= Time.deltaTime) <= 0)
            {
                isDefend = false;
                defendEffectPrefab.SetActive(false);
            }



        }
        else
        {
            defendEffectPrefab.SetActive(false);
        }
        //攻击间隔
        if (timeValue >= 0.6f)
        {
            Attack();
            timeValue = 0;

        }
        else
        {
            timeValue += Time.deltaTime;
        }
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

        MoveTank();
        changeDirectionTimeValue += Time.deltaTime;
        if (changeDirectionTimeValue >= 2.0f)
        {

            int num = Random.Range(0, changeRandoms.Length - 1);
            switch (changeRandoms[num])
            {
                case 4:
                    h = -1; v = 0;//左
                    break;
                case 2:
                    h = 0; v = -1;//下
                    break;
                case 6:
                    h = 1; v = 0;//右
                    break;
                case 8:
                    h = 0; v = 1;//上
                    break;
                default:
                    h = 0; v = 0;
                    break;
            }
            changeDirectionTimeValue = 0;

        }
        print("move");




    }
    private void Death()
    {
        if (!isDefend)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
         
        }
    }
    private void OnDestroy()
    {

        try
        {
            GameObject.Find("MapCreation").SendMessage("DestroyEnemy");
        }
        catch (System.Exception)
        {

            throw;
        }
        //GameObject.Find("PlayerManager").SendMessage("RefreshScore",this.tag,SendMessageOptions.DontRequireReceiver);
        PlayerManager.Instance.RefreshScore(this.Level+"");
    }
    private void Attack()
    {
        int i = Random.Range(0, 3);
        if (i == 1)
        {
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
           
        }


    }
    private void MoveTank()
    {

      

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            changeDirectionTimeValue =2.0f;
        }
    }
}
