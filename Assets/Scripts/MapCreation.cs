using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{

    public GameObject[] moditem;//初始化地图所需加载物体
                                //0.基地
                                //1.墙
                                //2.障碍
                                //3.出生效果
                                //4.河流
                                //5.草
                                //6.空气墙
    private Vector3 mapSize_1 = new Vector3(-11, -9, 0);
    private Vector3 mapSize_2 = new Vector3(11, 9, 0);
    private float creatEnemyTimeValue;
    private int enemyMaxSize;
    private int enemyCount;
    private List<Vector3> modPositionList = new List<Vector3>();
    private void Awake()
    {
        enemyMaxSize = 15; enemyCount = 0;
        creatEnemyTimeValue = 0;
        CreateMod(moditem[0], new Vector3(0, -8, 0), Quaternion.identity);
        //--------------
        CreateMod(moditem[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateMod(moditem[1], new Vector3(1, -8, 0), Quaternion.identity);
        //--------------


        for (int i = -11; i < 12; i++)
        {
            CreateMod(moditem[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateMod(moditem[6], new Vector3(i, -9, 0), Quaternion.identity);

        }
        for (int i = -8; i < 9; i++)
        {
            CreateMod(moditem[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateMod(moditem[6], new Vector3(11, i, 0), Quaternion.identity);

        }
        //随机生成地图
        //  CreatMapRandomMod();
        //----按需生成随机地图
        //1.墙
        //2.障碍
        //4.河流
        //5.草
        CreatMapNeedsMod();
        //产生玩家
        CreatePlayer();
        //产生敌对势力
        CreateMod(moditem[3], new Vector3(-10, 8, 0), Quaternion.identity);
        enemyCount++;
        CreateMod(moditem[3], new Vector3(0, 8, 0), Quaternion.identity);
        enemyCount++;
        CreateMod(moditem[3], new Vector3(10, 8, 0), Quaternion.identity);
        enemyCount++;




    }
    public void CreatePlayer()
    {

        GameObject player = Instantiate(moditem[3], new Vector3(-2, -8, 0), Quaternion.identity);
        player.GetComponent<Born>().IsGetPlayer = true;
    }
    private void CreateMod(GameObject _createObject, Vector3 _vector3, Quaternion _quaternion)
    {
        Instantiate(_createObject, _vector3, _quaternion).transform.SetParent(gameObject.transform);
        modPositionList.Add(_vector3);
    }

    /// <summary>
    /// 按需要生成随机地图
    /// </summary>
    /// <param name="wall">墙块数量</param>
    /// <param name="barrier">障碍块数量</param>
    /// <param name="sea">海块数量</param>
    /// <param name="grass">草块数量</param>
    private void CreatMapNeedsMod(int wall = 70, int barrier = 30, int sea = 15, int grass = 30)
    {
        for (int i = 0; i < wall; i++)
        {
            CreateMod(moditem[1], CreateRandomPosition(), Quaternion.identity);

        }
        for (int i = 0; i < barrier; i++)
        {
            CreateMod(moditem[2], CreateRandomPosition(), Quaternion.identity);

        }
        for (int i = 0; i < sea; i++)
        {
            CreateMod(moditem[4], CreateRandomPosition(), Quaternion.identity);

        }
        for (int i = 0; i < grass; i++)
        {
            CreateMod(moditem[5], CreateRandomPosition(), Quaternion.identity);

        }
    }
    /// <summary>
    /// 随机生成需要地图
    /// </summary>
    private void CreatMapRandomMod()//方法2
    {
        int[] ranmods = { 1, 1, 2, 4, 5 };
        //舍去X=10,-10 ;Y=8,-8  
        for (int i = -9; i < 10; i++)
        {
            for (int j = -6; j < 8; j++)
            {
                int rand = Random.Range(0, ranmods.Length + 1);
                if (rand != ranmods.Length)
                    CreateMod(moditem[ranmods[rand]], new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
    private Vector3 CreateRandomPosition()
    {
        //舍去X=10,-10 ;Y=8,-8
        for (;;)
        {
            Vector3 vector3random = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8));
            if (!HasThePosition(vector3random))
            {
                return vector3random;
            }

        }

    }
    private bool HasThePosition(Vector3 creatPos)
    {
        for (int i = 0; i < modPositionList.Count; i++)
        {
            if (creatPos.Equals(modPositionList[i]))
            {
                return true;
            }
        }
        return false;
    }
    // Use this for initialization
    //创建敌对势力计时器
    private void CreateEnemy()
    {
        if (creatEnemyTimeValue >= 4.0f && enemyCount <= enemyMaxSize)
        { 
            switch (Random.Range(0, 3))
            {
                case 0:
                    CreateMod(moditem[3], new Vector3(-10, 8, 0), Quaternion.identity);
                    break;
                case 1:
                    CreateMod(moditem[3], new Vector3(0, 8, 0), Quaternion.identity);
                    break;
                default:
                    CreateMod(moditem[3], new Vector3(10, 8, 0), Quaternion.identity);
                    break;
            }
            creatEnemyTimeValue = 0;

            enemyCount++;
        }
        creatEnemyTimeValue += Time.deltaTime;
    }
    void DestroyEnemy()
    {
        enemyCount--;
        print("destroy");
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CreateEnemy();
    }
}
