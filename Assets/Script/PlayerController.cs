using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D Player_rb;
    BoxCollider2D Player_col;
    Slider slider;


    public float power;
    public float nomal_speed;



    public float stamina_useable_time_max;
    public float stamina_de_time_max;

    Transform cabinet_trs;

    float direction;
    float speed;
    float stamina_useable_time;
    float stamina_de_time;
    float stemina_speed = 1.5f;
    float restroom_speed = 2f;

    
    Text skill;
    float buff_time = 5f;
    float skill_time = 30f;
    float see_cool;
    
    

    bool isbuff=false;
    bool isrest = true;
    bool iscan_hide=false;
    bool ishide=false;
    bool usestamina = false;
    bool ispenalti = false;

    
    // Start is called before the first frame update
    void Start()
    {
        see_cool = skill_time;
        skill=GameObject.Find("Skill").GetComponent<Text>();
        slider = GameObject.Find("Stamina").GetComponent<Slider>();//스테미나라는 객체를 찾아서 그안의 slider을 가져온다
        stamina_de_time = stamina_de_time_max;
        speed = nomal_speed;
        stamina_useable_time = stamina_useable_time_max;
        //speed = 0.3f;
        Player_rb= GetComponent<Rigidbody2D>();
        Player_col= GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        player_slider_update();//슬라이더를 업데이트 해줌
        
        if (!ishide)//숨지 않는경우에 움직이기 가능
        {
            player_move();
            if(isbuff==false)
                player_use_stamina();
        }
        

        if (iscan_hide)//캐비넷과 접촉했을때만
            player_hide();
        
        if(isrest)
        {
            skill_readyUI();
            useRest();
        }
        if(isrest==false&&isbuff==false)
        {
            skill_coolUI();
        }
    }
    void useRest()
    {
        if(Input.GetKey(KeyCode.R))
        {
            StartCoroutine(gorest());
        }
    }
    IEnumerator gorest()
    {
        SceneManager.LoadScene("Restroom");
        isrest = false;
        Player_rb.gravityScale = 0;
        isbuff = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
        Player_rb.gravityScale = 1;
        stamina_useable_time = stamina_useable_time_max;
        speed =nomal_speed* restroom_speed;
        usestamina = false;
        yield return new WaitForSeconds(buff_time);
        isbuff = false;
        speed = nomal_speed/ restroom_speed;
        //UnloadSceneOptions.
        yield return new WaitForSeconds(skill_time);
        isrest=true;
    }
    void skill_coolUI()
    {

        see_cool -= Time.deltaTime;
        skill.text = "Skill\n" + (int)see_cool;
    }
    void skill_readyUI()
    {
        see_cool = skill_time;
        skill.text = "Skill\n" +"Ready";
    }
    void player_slider_update()
    {
        slider.value = stamina_useable_time / stamina_useable_time_max;
    }
    void player_hide()
    {
       
        if (!ishide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player_rb.velocity = Vector2.zero;
                this.transform.position=cabinet_trs.position;
                gameObject.tag = "Untouchable";
                ishide = true;
                // Player_col.enabled = false;
            }
        }
        else
        {
            if (stamina_useable_time < stamina_useable_time_max)
            {
                stamina_useable_time += Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.tag = "Player";
                ishide = false;
                //스테미나 작용 
                {
                    speed = nomal_speed;
                    ispenalti = false;
                    stamina_de_time = stamina_de_time_max;
                    usestamina = false;
                }

            }
        }
    }
    void player_move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;

            // Player_rb.AddForce(new Vector2(direction * power * speed, 0f));
            transform.Translate(new Vector2(direction * power * speed,0f));
            //  Debug.Log("left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;

            //Player_rb.AddForce(new Vector2(direction * power * speed, 0f));
            transform.Translate(new Vector2(direction * power * speed, 0f));
            //   Debug.Log("right");
        }
    /*    if (Input.GetKeyUp(KeyCode.A)) 리지드 바디로 할시에 velocity를 없애야 멈추기에 이를 설정
        {

            //Player_rb.velocity = Vector2.zero;
            transform.Translate(new Vector2(direction * power * speed, 0f));
            //   Debug.Log("leftstop");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            //Player_rb.velocity = Vector2.zero;
            transform.Translate(new Vector2(direction * power * speed, 0f));
            // Debug.Log("rightstop");
        }*/
    }
    void player_use_stamina()
    {
        //Debug.Log(Player_rb.velocity);
       
        if (stamina_useable_time > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = nomal_speed* stemina_speed;
                usestamina = true;
                //  Debug.Log(speed);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed =nomal_speed/stemina_speed;
                usestamina = false;
                // Debug.Log(speed);
            }
        }

        if (usestamina)
        {
            stamina_useable_time -= Time.deltaTime;
            
            if(stamina_useable_time<0)
            {
                Debug.Log("isp");
                
                speed = nomal_speed / 2;
                ispenalti = true;
                usestamina = false;
            }
        }
        else if(!ispenalti)//스테미나를 사용하지 않고 페널티 상태가 아닐경우
        {
            if (stamina_useable_time < stamina_useable_time_max)
            {
                stamina_useable_time += Time.deltaTime;
            }
        }
        
        if(ispenalti)
        {
            Debug.Log(math.abs(Player_rb.velocity.x));
            if (math.abs(Player_rb.velocity.x) >= 2f)
            {
                Player_rb.AddForce(-Player_rb.velocity.normalized * nomal_speed); 
            }
            stamina_de_time -= Time.deltaTime;
            if(stamina_de_time<0)
            {
                speed = nomal_speed;
                Debug.Log("isnotp");
                ispenalti = false;
                stamina_de_time = stamina_de_time_max;
            }
        }
        

    }
    void OnTriggerStay2D(Collider2D other)//계속 충돌하고 있을시에 일어남
    {
        if (other.CompareTag("Cabinet")) // 충돌한 객체의 태그가 "Player"인 경우
        {
            cabinet_trs = other.transform;
            iscan_hide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cabinet")) // 충돌한 객체의 태그가 "Player"인 경우
        {
            iscan_hide = false;
        }
    }



}
