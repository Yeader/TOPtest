using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonsObj
{
    private Transform _keypress;
    public Transform Keypress
    {
        get { return _keypress; }
        set { _keypress = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private int _number;
    public int Number
    {
        get { return _number; }
        set {
            _number = 0;
            _number = value;
        }
    }

    private Vector2 _downpos;
    public Vector2 Downpos
    {
        get { return _downpos; }
        set { _downpos = value; }
    }

    private Vector2 _uppos;
    public Vector2 Uppos
    {
        get { return _uppos; }
        set { _uppos = value; }
    }

    private Vector3 _movedir;
    public Vector3 Movedir
    {
        get { return _movedir; }
        set { _movedir = value; }
    }

    private bool _ismove;
    public bool Ismove
    {
        get { return _ismove; }
        set { _ismove = value; }
    }

    private Vector2 _firstyucunPos;
    public Vector2 FirstyucunPos
    {
        get { return _firstyucunPos; }
        set { _firstyucunPos = value; }
    }

    /// <summary>
    /// 动画播放
    /// </summary>
    public void PlayerAni(string animation, Transform transone, Transform transtwo)
    {
        Keypress.GetComponent<Animator>().Play(animation);
        //Keypress.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.farClipPlane));
        Keypress.GetComponent<BoxCollider>().enabled = true;
        transone.GetComponent<BoxCollider>().enabled = false;
        transtwo.GetComponent<BoxCollider>().enabled = false;
    }
    public void PlayerAni(string animation)
    {
        Keypress.GetComponent<Animator>().Play(animation);
    }

    public void EnableTrue()
    {
        Keypress.GetComponent<BoxCollider>().enabled = true;
    }

    public void Move()
    {
        Keypress.Translate(-Movedir * Speed * Time.deltaTime);
    }


}
