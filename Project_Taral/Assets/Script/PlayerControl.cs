using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3.731f;
    private float jump = 5.0f;
    private float gravity = 14.0f;
    private float speedcoef;
    private float Height;

    public GameObject look;
    public GameObject ca;
    private bool acc = false;

    private int ballar = 0;
    private int ballglock = 0;
    private int heal = 0;
    private int code = 0;

    private int hp = 200;
    private float stamina = 100;
    public float time = 5f;

    private int life = 3;

    public GameObject[] arme;


    PhotonView view;
    public AudioClip SoundJump;
    private BoxCollider box;
    public BoxCollider boxh;
    static Animator anim;
    private CharacterController controller
    {
        get
        {
            return GetComponent<CharacterController>();
        }
    }
    void Start()
    {
        view = GetComponent<PhotonView>();
        box = GetComponent<BoxCollider>();
        speedcoef = 2.1f;
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (view.isMine)
        {
            float Horizont = 0;
            float Vertic = 0;
            if (Input.GetKey(Control.haut))
            {
                anim.SetBool("isWalking",true);
                Vertic = speed;
                if (Input.GetKey(Control.sprint) && stamina > 0)
                {
                    anim.SetBool("isRunning", true);
                    Vertic *= speedcoef;
                    stamina -= 0.3f;
                }
                else
                    anim.SetBool("isRunning", false);
            }
            if (Input.GetKey(Control.bas))
            {
                anim.SetBool("isWalking", true);
                Vertic = -speed;
            }
            if (Input.GetKey(Control.gauche))
            {
                anim.SetBool("isWalking", true);
                Horizont = -speed;
            }
            if (Input.GetKey(Control.droite))
            {
                anim.SetBool("isWalking", true);
                Horizont = speed;
            }
            if (controller.isGrounded)
            {
                Height = -gravity * Time.deltaTime;
                if (Input.GetKeyDown(Control.saut))
                {
                    Height = jump;
                    anim.SetTrigger("isJumping");
                }
            }
            else
            {
                Height -= gravity * Time.deltaTime;
            }
            if (Input.GetKey(Control.accroupir))
            {
                box.size = new Vector3(0.75f, 0.5f, 0.5f);
                box.center = new Vector3(0, 0.25f, 0);
                controller.height = 0.5f;
                controller.center = new Vector3(0, 0.25f, 0);
                look.gameObject.transform.position = new Vector3(look.gameObject.transform.position.x, transform.position.y +0.05f, look.gameObject.transform.position.z);
                ca.gameObject.transform.position = new Vector3(ca.gameObject.transform.position.x, transform.position.y + 0.05f, ca.gameObject.transform.position.z);
                acc = true;
            }
            else if (acc)
            {
                
                box.size = new Vector3(0.75f, 2f, 0.5f);
                box.center = new Vector3(0, 1f, 0);
                controller.height = 2f;
                controller.center = new Vector3(0, 1f, 0);
                look.gameObject.transform.position = new Vector3(look.gameObject.transform.position.x, transform.position.y + 1.7f, look.gameObject.transform.position.z);
                ca.gameObject.transform.position = new Vector3(ca.gameObject.transform.position.x, transform.position.y + 1.7f, ca.gameObject.transform.position.z);
                acc = false;
            }
            Vector3 move = Vector3.zero;
            move.x = Horizont;
            move.y = Height;
            move.z = Vertic;
            transform.Rotate(0, Input.GetAxis("Mouse X") * 180 * Time.deltaTime, 0);
            move = transform.TransformDirection(move);
            if (move.x != 0 && move.y != 0 && move.z != 0)
            {
                controller.Move(move * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isWalking", false);
                controller.Move(move * Time.deltaTime);
            }

            if (stamina <= 0)
            {
                if (time <= 0)
                {
                    stamina = 100;
                }
                time -= Time.deltaTime;
            }
            else
            {
                time = 5f;
            }
        }
    }


    public void add(int i)
    {
        if (i == 0)
        {
            ballar += 30;
        }
        else if (i == 1)
        {
            ballglock += 8;
        }
        else if (i == 2)
        {
            heal += 1;
        }
        else
        {
            code += 1;
        }
    }
    public int ar()
    {
        return ballar;
    }
    public int glo()
    {
        return ballglock;
    }
    public int he()
    {
        return heal;
    }
    public int c()
    {
        return code;
    }


    public int gethp()
    {
        return hp;
    }
    public float getstamina()
    {
        return stamina;
    }
    public void pertehp(int i)
    {
        hp -= i;
    }
    public int getlife()
    {
        return life;
    }
    public int getcode()
    {
        return code;
    }
    public void resetlife(Vector3 v)
    {
        ballar = 0;
        ballglock = 0;
        heal = 0;
        code = 0;
        hp = 200;
        controller.transform.position = v;
        life -= 1;
    }

    public void arm(int i)
    {
        arme[i].gameObject.SetActive(true);
    }

    public void tirarm(int i)
    {
        if (i == 0 && ballar > 0)
        {
            arme[i].GetComponent<Fire>().fire();
            ballar -= 1;
        }
        else if (i == 1 && ballglock > 0)
        {
            arme[i].GetComponent<Fire>().fire();
            ballglock -= 1;
        }
        else if (i == 3 && heal > 0)
        {
            heal -= 1;
            hp += 30;
        }
    }

    public void resetarm()
    {
        foreach(var a in arme)
        {
            a.gameObject.SetActive(false);
        }
    }
}