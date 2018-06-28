using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickTest : MonoBehaviour
{

    Ray myray;
    //RaycastHit myhit;
    ButtonsObj yucun, meishi, haigang;
    public Animator yucunani;
    public Image showUI;
    public Sprite yucunjietu, meishijietu, haigangjietu;
    private Type type;
    UDPClient myclient;
    // Use this for initialization
    void Start()
    {
        yucun = new ButtonsObj();
        meishi = new ButtonsObj();
        haigang = new ButtonsObj();
        yucun.Keypress = transform.Find("Panel/yucun");

        yucun.Ismove = true;

        Screen.SetResolution(2048, 1536, false);
        Debug.logger.logEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(myray))
            {
                yucun.Ismove = false;
                yucun.Downpos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (yucun.Ismove == false)
            {
                yucun.Uppos = Camera.main.WorldToScreenPoint(Input.mousePosition);
                yucun.Ismove = true;
            }
            else
            {
                yucun.Uppos = yucun.Downpos;
            }

            if ((yucun.Downpos.y - yucun.Uppos.y) < 0)
            {
                yucun.Ismove = true;
                yucun.PlayerAni("anifly");
                startnumber();
            }
            else
            {

            }
        }
        //Debug.Log(yucun.Keypress.localPosition.y);
        if (yucun.Keypress.localPosition.y > 1200f)
        {
            switch (type)
            {
                case Type.yucun:
                    Debug.Log("yucun");
                    UDPClient.Instance.SocketSend("yucun");

                    type = Type.initial;
                    break;
                case Type.meishi:
                    Debug.Log("meishi");
                    UDPClient.Instance.SocketSend("meishi");
                    type = Type.initial;
                    break;
                case Type.haigang:
                    Debug.Log("haigang");
                    UDPClient.Instance.SocketSend("haigang");
                    type = Type.initial;
                    break;
            }
            yucunani.Play("keke");
        }
    }

    public void PlayYucun()
    {
        type = Type.yucun;
        showUI.sprite = yucunjietu;
        if (yucun.Number == 0)
        {
            yucunani.Play("yucunmove");
            startnumber();
            yucun.Number = 1;
        }
        else
        {
            yucunani.Play("yucunback");
            startnumber();
        }

    }

    public void PlayMeishi()
    {
        type = Type.meishi;
        showUI.sprite = meishijietu;
        if (meishi.Number == 0)
        {
            yucunani.Play("meishimove");
            startnumber();
            meishi.Number = 1;
        }
        else
        {
            yucunani.Play("meishiback");
            startnumber();
        }

    }
    public void PlayHaigang()
    {
        type = Type.haigang;
        showUI.sprite = haigangjietu;
        if (haigang.Number == 0)
        {
            yucunani.Play("haigangmove");
            startnumber();
            haigang.Number = 1;
        }
        else
        {
            yucunani.Play("haigangback");
            startnumber();
        }

    }
    public void startnumber()
    {
        meishi.Number = 0;
        haigang.Number = 0;
        yucun.Number = 0;
    }
    public enum Type
    {
        initial,
        yucun,
        meishi,
        haigang
    }

}
