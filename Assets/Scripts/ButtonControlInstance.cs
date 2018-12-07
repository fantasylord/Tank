using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControlInstance:IPointerDownHandler, IPointerUpHandler  {




    [DllImport("user32.dll", EntryPoint = "keybd_event")]

    public static extern void Keybd_event(

    byte bvk,//虚拟键值 ESC键对应的是27

    byte bScan,//0

    int dwFlags,//0为按下，1按住，2释放

    int dwExtraInfo//0

    );

    private Player player;
    private Main_Option mainoption;
    private static ButtonControlInstance instance=new ButtonControlInstance();
    private ScenesChoice scene;
    public List<GameObject> buttonList;

    private ButtonControlInstance()
    {
        buttonList = new List<GameObject>();
    }
    public static ButtonControlInstance Instance
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

    public ScenesChoice Scene
    {
        get
        {
            return scene;
        }

        set
        {
            scene = 0;
        }
    }

    public enum ScenesChoice
    {
        valueNull, mainScene = 1, gameScene
    }
    public void SetPlayer(Player _player)
    {
        player = _player;
        scene = ScenesChoice.gameScene;
        SetButtonlist();

    }
    public void SetStart(Main_Option _mainOption)
    {
        mainoption = _mainOption;
        scene = ScenesChoice.mainScene;
        SetButtonlist();
    }

    public List<GameObject>  FindButton()
    {
        List<GameObject> list=new List<GameObject>();
        try
        {
            list.Add(GameObject.Find("Button_j"));
            list.Add(GameObject.Find("Button_u"));
            list.Add(GameObject.Find("Button_d"));
            list.Add(GameObject.Find("Button_l"));
            list.Add(GameObject.Find("Button_r"));
        }
        catch (System.Exception)
        {

            throw;
        }
        return list;
    }
    public void SetButtonlist()
    {
        buttonList.Clear();
        buttonList = FindButton();
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

        PointerEventData a = eventData;
        GameObject button = null;
        List<GameObject> golist = eventData.hovered;
        int length = golist.Count;
        int length_buttonlist = buttonList.Count;
        bool flag = false;
        for (int i = 0; i < length_buttonlist; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (buttonList[i] == golist[j])
                {
                    button = golist[j]; flag = true; break;
                }
            }
            if (flag)
            {
                break;
            }

        }
        if (button == null)
            return;
        // a.hovered.Find()
        //print("按下" + button.tag);
        switch (scene)
        {
            case ScenesChoice.valueNull:
                break;
            case ScenesChoice.mainScene:
                switch (button.tag)
                {
                    case "up":
                        //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68
                        mainoption.ChooseOption(Main_Option.Chioce.chiocePos1);

                        break;
                    case "down":
                        //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68
                        mainoption.ChooseOption(Main_Option.Chioce.chiocePos2);

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                    case "j":
                        //   Keybd_event(74, 0, 1, 0);
                        mainoption.ChooseOption(Main_Option.Chioce.sureClick);

                        break;
                    default:
                        break;
                }
                break;
            case ScenesChoice.gameScene:
                switch (button.tag)
                {
                    case "up":
                        //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.up);
                       
                        break;
                    case "down":
                        //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.down);
                        break;
                    case "left":
                        //  Keybd_event(65, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.left);
                        break;
                    case "right":
                        // Keybd_event(68, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.right);
                        break;
                    case "j":
                        //   Keybd_event(74, 0, 1, 0);
                        player.MoveNeedButtonNum(Player.ButtonEnum.hit);
                        break;
                    default:
                        player.MoveNeedButtonNum(Player.ButtonEnum.value); OnPointerUp(eventData);
                        break;
                }
                break;
            default:
                break;
        }



    }

    public void OnPointerUp(PointerEventData eventData)
    {


        PointerEventData a = eventData;
        GameObject button = null;
        List<GameObject> golist = eventData.hovered;
        int length = golist.Count;
        int length_buttonlist = buttonList.Count;
        bool flag = false;
        for (int i = 0; i < length_buttonlist; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (buttonList[i] == golist[j])
                {
                    button = golist[j]; flag = true; break;
                }
            }
            if (flag)
            {
                break;
            }

        }
        if (button == null)
            return;
        // a.hovered.Find()
        //print("弹起" + button.tag);
        switch (scene)
        {
            case ScenesChoice.valueNull:
                break;
            case ScenesChoice.mainScene:
                switch (button.tag)
                {
                    case "up":
                        //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68
                        mainoption.ChooseOption(Main_Option.Chioce.chiocePos1);

                        break;
                    case "down":
                        //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68
                        mainoption.ChooseOption(Main_Option.Chioce.chiocePos2);

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                    case "j":
                        //   Keybd_event(74, 0, 1, 0);
                        mainoption.ChooseOption(Main_Option.Chioce.sureClick);

                        break;
                    default:
                        break;
                }
                break;
            case ScenesChoice.gameScene:
                switch (button.tag)
                {
                    case "up":
                        //  Keybd_event(87, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.value);

                        break;
                    case "down":
                        //  Keybd_event(83, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.value);
                        break;
                    case "left":
                        //  Keybd_event(65, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.value);
                        break;
                    case "right":
                        // Keybd_event(68, 0, 1, 0); //W87 S83 A65 D68
                        player.MoveNeedButtonNum(Player.ButtonEnum.value);
                        break;
                    case "j":
                        //   Keybd_event(74, 0, 1, 0);
                        player.MoveNeedButtonNum(Player.ButtonEnum.hit);
                        break;
                    default:
                        player.MoveNeedButtonNum(Player.ButtonEnum.value);
                        break;
                }
                break;
            default:
                break;
        }



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
        ////print("弹起" + button.tag);
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
    }
    // Update is called once per frame
    void Update()
    {

    }
}
