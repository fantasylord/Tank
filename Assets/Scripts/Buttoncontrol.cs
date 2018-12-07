using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttoncontrol : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{



    //[DllImport("user32.dll", EntryPoint = "keybd_event")]

    //public static extern void Keybd_event(

    //byte bvk,//虚拟键值 ESC键对应的是27

    //byte bScan,//0

    //int dwFlags,//0为按下，1按住，2释放

    //int dwExtraInfo//0

    //);

    public List<GameObject> buttonList;
    private Buttoncontrol()
    {
        buttonList = new List<GameObject>();
    }





    public enum ScenesChoice
    {
        valueNull, mainScene = 1, gameScene
    }

    private void Awake()
    {
        buttonList.Add(GameObject.Find("Button_j"));
        buttonList.Add(GameObject.Find("Button_u"));
        buttonList.Add(GameObject.Find("Button_d"));
        buttonList.Add(GameObject.Find("Button_l"));
        buttonList.Add(GameObject.Find("Button_r"));
        print("按键加载");

    }
    // Use this for initialization
    void Start()
    {

    }
    //h = -1; v = 0;//左 W87 S83 A	65 D68
    //                break;
    //            case 2:
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

    public void OnPointerDown(PointerEventData eventData)
    {
        #region test

        //PointerEventData a = eventData;
        //GameObject button = null;
        //List<GameObject> golist = eventData.hovered;
        //int length = golist.Count;
        //int length_buttonlist = buttonList.Count;
        //bool flag = false;
        //for (int i = 0; i < length_buttonlist; i++)
        //{
        //    for (int j = 0; j < length; j++)
        //    {
        //        if (buttonList[i] == golist[j])
        //        {
        //            button = golist[j]; flag = true; break;
        //        }
        //    }
        //    if (flag)
        //    {
        //        break;
        //    }

        //}
        //if (button == null)
        //    return;
        //// a.hovered.Find()
        //print("按下" + button.tag);
        //switch (scene)
        //{
        //    case ScenesChoice.valueNull:
        //        break;
        //    case ScenesChoice.mainScene:
        //        switch (button.tag)
        //        {
        //            case "up":
        //                //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68


        //                break;
        //            case "down":
        //                //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68

        //                break;
        //            case "left":
        //                //  Keybd_event(65, 0, 1, 0); //W87 S83 A65 D68

        //                break;
        //            case "right":
        //                // Keybd_event(68, 0, 1, 0); //W87 S83 A65 D68

        //                break;
        //            case "j":
        //                //   Keybd_event(74, 0, 1, 0);

        //                break;
        //            default:
        //                break;
        //        }
        //        break;
        //    case ScenesChoice.gameScene:
        //        switch (button.tag)
        //        {
        //            case "up":
        //                //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68
        //                player.MoveTank(Player.ButtonEnum.up);

        //                break;
        //            case "down":
        //                //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68
        //                player.MoveTank(Player.ButtonEnum.down);
        //                break;
        //            case "left":
        //                //  Keybd_event(65, 0, 1, 0); //W87 S83 A65 D68
        //                player.MoveTank(Player.ButtonEnum.left);
        //                break;
        //            case "right":
        //                // Keybd_event(68, 0, 1, 0); //W87 S83 A65 D68
        //                player.MoveTank(Player.ButtonEnum.right);
        //                break;
        //            case "j":
        //                //   Keybd_event(74, 0, 1, 0);
        //                player.MoveTank(Player.ButtonEnum.hit);
        //                break;
        //            default:
        //                break;
        //        }
        //        break;
        //    default:
        //        break;
        //}


        #endregion
        ButtonControlInstance.Instance.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        #region test

        //PointerEventData a = eventData;
        //GameObject button = null;
        //List<GameObject> golist = eventData.hovered;
        //int length = golist.Count;
        //int length_buttonlist = buttonList.Count;
        //bool flag = false;
        //for (int i = 0; i < length_buttonlist; i++)
        //{
        //    for (int j = 0; j < length; j++)
        //    {
        //        if (buttonList[i] == golist[j])
        //        {
        //            button = golist[j]; flag = true; break;
        //        }
        //    }
        //    if (flag)
        //    {
        //        break;
        //    }

        //}
        //if (button == null)
        //    return;
        //print("弹起" + button.tag);
        //switch (button.tag)
        //{
        //    case "up":
        //        Keybd_event(87, 0, 2, 0); //W87 S83 A65 D68

        //        break;
        //    case "down":
        //        Keybd_event(83, 0, 2, 0); //W87 S83 A65 D68
        //        break;
        //    case "left":
        //        Keybd_event(65, 0, 2, 0); //W87 S83 A65 D68
        //        break;
        //    case "right":
        //        Keybd_event(68, 0, 2, 0); //W87 S83 A65 D68

        //        break;
        //    case "j":
        //        Keybd_event(74, 0, 2, 0);
        //        break;
        //    default:
        //        break;
        //}
        #endregion
    }
    // Update is called once per frame
    void Update()
    {

    }
}
