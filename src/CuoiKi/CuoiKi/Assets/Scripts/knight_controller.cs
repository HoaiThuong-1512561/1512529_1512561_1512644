using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knight_controller : MonoBehaviour
{

    public float speed = 8f;
    public float maxVelocity = 2f;
    public Image healthBar;
    public Text textHp;
    //[SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private AudioSource audio;
    //[SerializeField]
    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;
    public GameObject bombObject;
    public GameObject trapObject;
    private bool key = false;
    public static Action GoToMap1;
    public static Action OnNotKey;
    public static Action GoToMap2;
    public static Action GoToMap3;
    public static Action GoToMap4;
    public static Action ShowPanelHelp;
    public static Action Die;
    public GameObject keyImageObject;
    public Text textHelp;
    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio= GetComponent<AudioSource>();
        //bar = healthBar.GetComponent<Image>();
        textHp.text= PlayerInfo.hp + "/100";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Health();
       
            PlayerMoveKeyBoard();
        
        attack();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name=="ghost")
            EndGame();
        if (other.collider.tag == "Soldier")
        {
            PlayerInfo.hp-= 20;
            if (PlayerInfo.hp < 0)
            {
                PlayerInfo.hp = 0;
            }
            textHp.text = PlayerInfo.hp + "/100";
        }
        if (other.collider.tag == "animal")
        {
            PlayerInfo.hp -= 10;
            if (PlayerInfo.hp < 0)
            {
                PlayerInfo.hp = 0;
            }
            textHp.text = PlayerInfo.hp + "/100";
        }
        if (other.collider.tag == "danger")
        {
            PlayerInfo.hp -= 50;
            if (PlayerInfo.hp < 0)
            {
                PlayerInfo.hp = 0;
            }
            textHp.text = PlayerInfo.hp + "/100";
        }
        if (other.collider.tag == "nextMap")
        {
            if (!key)
            {
                OnNotKey();
            }
            else
            {
                GoToMap2();
            }
        }
        if (other.collider.tag == "nextMap1")
        {
            if (!key)
            {
                OnNotKey();
            }
            else
            {
                GoToMap1();
            }
        }
        if (other.collider.tag == "nextMap2")
        {
            if (!key)
            {
                OnNotKey();
            }
            else
            {
                GoToMap3();
            }
        }
        if (other.collider.tag == "nextMap3")
        {
            if (Data.numberSodierDie <= 0)
            {
                key = true;
            }
            if (!key)
            {
                OnNotKey();
            }
            else
            {
                GoToMap4();
            }
        }
        if (PlayerInfo.hp == 0)
        {
            Die();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("itemBomb"))
        {
            if (Data.music == 0)
            {
                audio.Play();
            }
            PlayerInfo.numberBomb++;
            ItemsControler.items[0].setItem(PlayerInfo.numberBomb);
        }else if (other.gameObject.CompareTag("itemTrap"))
        {
            if (Data.music == 0)
            {
                audio.Play();
            }
            PlayerInfo.numberTrap++;
            ItemsControler.items[1].setItem(PlayerInfo.numberTrap);
            if (Data.firstMap)
            {
                textHelp.text = "-Bạn vừa nhặt được 1 vật phẩm bẫy gấu. Bấm phím 2 để sử dụng vật phẩm.\n- Trong suốt hành trình bạn sẽ nhặt được rất nhiều vật phẩm khác nhau.Bạn có thể xem cách sử dụng hay số lượng bên phía trái màn hình\n\n-Hãy tiếp tục đi tìm chìa khóa để mở cánh cổng rời khỏi bản đồ";
                ShowPanelHelp();
            }
        }
        else if (other.gameObject.CompareTag("key"))
        {
            if (Data.music == 0)
            {
                audio.Play();
            }
            
            if (!key)
            {
                keyImageObject.SetActive(true);
                key = true;
            }
            if (Data.firstMap)
            {
                textHelp.text = "-Xin chúc mừng bạn vừa tìm thấy chìa khóa\n- Bây giờ bạn hãy đi tìm cánh cổng và sử dụng chìa khóa để ra khỏi đây";
                ShowPanelHelp();
            }
        }
    }

    void OnCollisionStay()
    {

    }
    void OnCollisionExit()
    {

    }
    void Health()
    {
        if (healthBar.fillAmount > PlayerInfo.hp / 100)
        {
            healthBar.fillAmount -= 0.01f;
        }
    }
    void EndGame() {
        PlayerInfo.hp -= 20;
        if (PlayerInfo.hp < 0)
        {
            PlayerInfo.hp = 0;
        }
        textHp.text = PlayerInfo.hp + "/100";

    }
    void PlayerMoveKeyBoard()
    {
        if (!Data.showPanelHelp)
        {
            float forxeY = 0f;
            float forxeX = 0f;
            float velX = Mathf.Abs(myBody.velocity.x);
            float velY = Mathf.Abs(myBody.velocity.y);
            float keyU = Input.GetAxisRaw("Vertical");
            float keyL = Input.GetAxisRaw("Horizontal");


            if (keyU > 0 && keyL == 0)
            {
                if (velY < maxVelocity)
                {
                    forxeY = speed;
                }

                if (!up)
                {
                    up = true;

                    anim.Play("knight_up", -1, 0f);

                    down = false;
                    left = false;
                    right = false;
                    anim.SetBool("up", true);
                }

            }
            else if (keyU < 0 && keyL == 0)
            {
                if (velY < maxVelocity)
                {
                    forxeY = -speed;
                }

                if (!down)
                {
                    down = true;
                    anim.Play("knight_down", -1, 0f);
                    up = false;
                    left = false;
                    right = false;
                    anim.SetBool("down", true);
                }

            }
            //--------------------------------------------

            if (keyL > 0 && keyU == 0)
            {
                if (velX < maxVelocity)
                {
                    forxeX = speed;
                }

                if (!right)
                {
                    right = true;
                    anim.Play("knight_right", -1, 0f);
                    up = false;
                    down = false;
                    left = false;
                    anim.SetBool("right", true);
                }

            }
            else if (keyL < 0 && keyU == 0)
            {
                if (velX < maxVelocity)
                {
                    forxeX = -speed;
                }

                if (!left)
                {
                    left = true;
                    anim.Play("knight_left", -1, 0f);
                    up = false;
                    down = false;
                    right = false;
                    anim.SetBool("left", true);
                }
            }

            if (keyL == 0 && keyU == 0)
            {

                myBody.velocity = Vector3.zero;

                if (left)
                    anim.Play("Idle_knight_left", -1, 0f);
                if (right)
                    anim.Play("Idle_knight_right", -1, 0f);
                if (up)
                    anim.Play("Idle_knight_up", -1, 0f);
                if (down)
                    anim.Play("Idle_knight_down", -1, 0f);

                left = false;
                right = false;
                up = false;
                down = false;
                anim.SetBool("up", false);
                anim.SetBool("down", false);
                anim.SetBool("right", false);
                anim.SetBool("left", false);
            }
            float moveSpeed = 2f;
            Vector3 dir = new Vector3(forxeX, forxeY, 0f);
            dir = dir.normalized;
            myBody.velocity = dir * moveSpeed;
        }
        else
        {
            float moveSpeed = 2f;
            Vector3 dir = new Vector3(0, 0, 0f);
            dir = dir.normalized;
            myBody.velocity = dir * moveSpeed;
            anim.Play("Idle_knight_down", -1, 0f);
        }
       
    }
    void attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (PlayerInfo.numberBomb > 0)
            {
                Instantiate(bombObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                PlayerInfo.numberBomb--;
                ItemsControler.items[0].setItem(PlayerInfo.numberBomb);
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (PlayerInfo.numberTrap > 0)
            {
                Instantiate(trapObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                PlayerInfo.numberTrap--;
                ItemsControler.items[1].setItem(PlayerInfo.numberTrap);
            }
        }
    }
}
