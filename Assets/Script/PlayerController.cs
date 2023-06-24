using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class PlayerController : MonoBehaviour
{

    static bool enemy_appear = false;
    public static bool scene_move = false;
    public static bool scene_update = false;
    public static bool scene_move_center=false;
    Scene scene;
    Rigidbody2D Player_rb;
    BoxCollider2D Player_col;
    Slider slider;
    GameObject door;
    Canvas stamina_skill_ui;
    Canvas phone;
    Animator animator;
    public float power;
    public float nomal_speed;
    static Vector3 localscale;
    Vector3 spawn_point;
    SpriteRenderer sprite;
    AudioSource walk;
    AudioSource run;
    AudioSource doorEf;
    int s_namesize;
    string []not_visible_S_name;
    public float stamina_useable_time_max;
    public float stamina_de_time_max;

    Transform cabinet_trs;

    float direction;
    float speed;
    float stamina_useable_time;
    float stamina_de_time;
    float stemina_speed = 1.5f;
    float restroom_speed = 2.0f;

    
    Image skill;
    float buff_time = 5f;
    float skill_time = 10f;
    float get_skill_cool;


    bool isspawn = false;
    bool isinside = false;
    bool isbuff=false;
    bool isrest = true;
    bool iscan_hide=false;
    static bool ishide=false;
    bool usestamina = false;
    bool ispenalti = false;
    int div;
    bool cool=false;

    GameObject audio_director;//오디오 디렉터
    GameObject blind;//암막용
    Transform left = null; //왼쪽 포탈의 위치
    Transform right = null;//오른쪽 포탈의 위치
    Transform center=null;
    // Start is called before the first frame update
    private void Awake()
    {
        localscale = transform.localScale;
        spawn_point = transform.position;
    }
    void Start()
    {
        
        walk = transform.Find("Walk").GetComponent<AudioSource>();
        run = transform.Find("Run").GetComponent<AudioSource>();
        doorEf=transform.Find("DoorEf").GetComponent<AudioSource>() ;
        blind = transform.Find("Blind").gameObject;
        sprite = GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        get_skill_cool= 0;
        skill=GameObject.Find("Image").GetComponent<Image>();
        slider = GameObject.Find("Stamina").GetComponent<Slider>();//���׹̳���� ��ü�� ã�Ƽ� �׾��� slider�� �����´�
        stamina_de_time = stamina_de_time_max;
        speed = nomal_speed;
        stamina_useable_time = stamina_useable_time_max;
        //speed = 0.3f;
        Player_rb= GetComponent<Rigidbody2D>();
        Player_col= GetComponent<BoxCollider2D>();
        P_set_Not_visble_name_set();
        StartCoroutine(Find_audio());
        StartCoroutine(Find_enemy());
        StartCoroutine(Find_canvas_st());
        StartCoroutine(Find_canvas_ph());
    }
    IEnumerator Find_canvas_st() 
    {
        yield return new WaitForSeconds(0.3f);
        if (GameObject.FindWithTag("Stamina") == null)
        {
            StartCoroutine(Find_canvas_st());
        }
        else
        {
            stamina_skill_ui = GameObject.FindWithTag("Stamina").GetComponent<Canvas>();
            yield break;
        }
    }
    IEnumerator Find_canvas_ph()
    {
        yield return new WaitForSeconds(0.3f);
        if (GameObject.FindWithTag("Phone") == null)
        {
            StartCoroutine(Find_canvas_ph());
        }
        else
        {
            phone = GameObject.FindWithTag("Phone").GetComponent<Canvas>();
            yield break;
        }
    }
    void Audio_play()
    {
        if (audio_director == null) return;
        if (enemy_appear == true)
        { 
            audio_director.GetComponentInChildren<AudioSource>().Stop();
            return;
        }
        if(enemy_appear == false)
            if(audio_director.transform.Find("BGM").gameObject.GetComponent<AudioSource>().isPlaying==false)
                audio_director.transform.Find("BGM").gameObject.GetComponent<AudioSource>().Play();

        
    }
    IEnumerator Find_enemy()
    {
        yield return new WaitForSeconds(0.3f);
        if (GameObject.FindWithTag("Enemy") == null)
        {
            enemy_appear = false;
        }
        else
        {
            enemy_appear = true;
        }
        Audio_play();
        StartCoroutine(Find_enemy());
    }
    IEnumerator Find_audio()
    {
        yield return new WaitForSeconds(0.3f);
        if(GameObject.FindWithTag("Audio_director")==null)
        {
            StartCoroutine(Find_audio()); 
        }
        else 
        {
            audio_director = GameObject.FindWithTag("Audio_director");
            yield break;
        }
    }
    IEnumerator Find_left_right(Transform left, Transform right)
    {

        yield return new WaitForSeconds(0.1f);
        if (scene_move == false) yield return null;
        else if (GameObject.FindWithTag("Left") == null)
        {
            StartCoroutine(Find_left_right(left, right));
        }
        else if (GameObject.FindWithTag("Right") == null)
        {
            StartCoroutine(Find_left_right(left, right));
        }
        else
        {
            
            scene_move = false;
            scene_update = true;
            left = GameObject.FindWithTag("Left").GetComponent<Transform>();
            right = GameObject.FindWithTag("Right").GetComponent<Transform>();
            //center = GameObject.FindWithTag("Center").GetComponent<Transform>();
            set_l_R(left, right);
            StopAllCoroutines();
            //Debug.Log(left.position);
            //Debug.Log(right.position);

        }
 /*       if (left != null && right != null)
            yield return null;
        else 
        {
            StartCoroutine(Find_left_right(left,right));
        }*/
    }
    IEnumerator Find_center(Transform center)
    {
        yield return new WaitForSeconds(0.1f);
        if (scene_move_center == false) yield return null;
        else if (GameObject.FindWithTag("Center") == null)
        {
            StartCoroutine(Find_center(center));
        }
        else
        {
            scene_move_center = false;
            scene_update = true;
            center = GameObject.FindWithTag("Center").GetComponent<Transform>();
            set_C(center);
            //center = GameObject.FindWithTag("Center").GetComponent<Transform>();
            StopAllCoroutines();
            //Debug.Log(left.position);
            //Debug.Log(right.position);

        }
    }
    void set_l_R(Transform _left, Transform _right){ left = _left;right = _right; }
    void set_C(Transform _center) { center = _center; }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scene_move);
        if(scene_move)
        {
             
            StartCoroutine(Find_left_right( left, right));

        }
        if(scene_move_center)
        {
            StartCoroutine(Find_center(center));
            play_door_ef();
        }
        if(scene_update)
        {
            //DataManager.instance.LoadData();
            DataManager.instance.LoadData();
            div = DataManager.instance.playerData.movedirection;
            Debug.Log(div);
            if (div == -1) transform.position = new Vector3(right.position.x,transform.position.y,0);// +new Vector3(-10,0,0);
            if (div == 1) transform.position = new Vector3(left.position.x, transform.position.y, 0);// +new Vector3(10,0,0);
            if(div==0) transform.position = new Vector3(center.position.x, transform.position.y, 0);
            scene_update =false;
        }
        //Debug.Log(spawn_point);
        StartCoroutine(P_isnotvisible_scene());
        if(stamina_skill_ui != null)
            player_slider_update();//�����̴��� ������Ʈ ����
        
        if (!ishide)//���� �ʴ°�쿡 �����̱� ����
        {
            player_move();
            if(isbuff==false)
                player_use_stamina();
        }
        door_in();//����ü��Ƿ� ���� �Լ�
  
        if (iscan_hide)//ĳ��ݰ� ������������
            player_hide();
        
        if(isrest)
        {
            skill_readyUI();
            useRest();
        }
        if(isrest==false&&isbuff==false)
        {
            //cool=true;
            /*skill_coolUI();*/
            StartCoroutine(cool_up());
        }
    }
    //create game set names not visible scene
    static public void set_move_scene_center() { scene_move_center = true; }
    static public void set_move_scene() { scene_move = true; }
    void P_set_Not_visble_name_set()
    {
        s_namesize = 10;
        not_visible_S_name = new string[s_namesize];//c#에서는 garbage콜렉터가 해당하는 공간을 삭제해줌
        not_visible_S_name[0] = "Loading";
        not_visible_S_name[1] = "inside";
        not_visible_S_name[2] = "Title";
    }
    IEnumerator Velocity_zero()
    {
        Player_rb.velocity= Vector3.zero;
        yield return new WaitForSeconds(0.5f);
    }
    void P_spawn() { transform.position = spawn_point; Player_rb.gravityScale = 1; }
    //is not visible scene? check function
    IEnumerator P_isnotvisible_scene()
    {
        yield return new WaitForSeconds(0.8f);
        scene = SceneManager.GetActiveScene();
        int count = 0;
        for (int i = 0; i < s_namesize; i++)
        {
            if (not_visible_S_name[i] == null)
                break;
            if (not_visible_S_name[i] == scene.name)
            {
                P_sprite_N_visible();
                canvas_invisible();
                count++;
                
                break;
            }
        }
        if (count == 0)
        {
            P_sprite_Y_visible();
            canvas_visible();
            //P_spawn();
            if (isspawn)
            {
                StartCoroutine(Velocity_zero());
                P_spawn();
                isspawn = false;
            }
        }
        
        
    }
    void canvas_invisible()
    {
        if(stamina_skill_ui != null)
            stamina_skill_ui.enabled = false;
        if (phone != null)
            phone.enabled = false;
    }

    void canvas_visible()
    {
        if (stamina_skill_ui != null)
            stamina_skill_ui.enabled = true;
        if (phone != null)
            phone.enabled = true;
    }
    public void play_door_ef()
    {
        doorEf.Play();
    }
    void P_defaultSetting()
    {
        stamina_de_time = stamina_de_time_max;
        speed = nomal_speed;
        stamina_useable_time = stamina_useable_time_max;
    }
    void P_sprite_N_visible() { sprite.enabled = false; }
    void P_sprite_Y_visible() { sprite.enabled = true; }
    IEnumerator goinside()
    {
        isinside = true;
        SceneManager.LoadScene("inside");
        yield return new WaitForSeconds(0.1f);
        //P_isnotvisible_scene();
        Player_rb.gravityScale = 0;
        P_sprite_N_visible();
        
        stamina_useable_time = 0;
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (GameObject.Find("DialogTest").GetComponent<DialogTest>().IsDialogEnd()==true)
            {
                if (Input.anyKeyDown||Input.anyKey)
                {
                    SceneManager.LoadScene("Title");
                    yield return new WaitForSeconds(0.1f);
                    isspawn = true;
                    //P_isnotvisible_scene();
                    /*P_sprite_N_visible();
                    P_spawn();*/
                    break;
                }
            }
            yield return new WaitForSeconds(2f);
        }
        
    }
    void door_in()
    {
        if (Input.GetKey(KeyCode.E))
        {
            door = GameObject.Find("door");
            if (door == null) ;
            else
            {
                bool ison = door.GetComponent<E_On_GUI>().Getison();
                if (door != null && ison == true)
                {
                    play_door_ef();
                    StartCoroutine(goinside());
                }
            }
            //door = GameObject.Find("RandomDoor_ctr").GetComponent<Door_spawner>().Getobject();
        }
    }

    void useRest()
    {
        if(Input.GetKey(KeyCode.R)&&!isinside)
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
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Restroom_floor");
        Player_rb.gravityScale = 1;
        stamina_useable_time = stamina_useable_time_max;
        speed =nomal_speed* restroom_speed ;
        usestamina = false;
        skill.fillAmount = 0;
        yield return new WaitForSeconds(buff_time);
        isbuff = false;
        speed = nomal_speed/ restroom_speed ;
        //UnloadSceneOptions.
        
    }

    IEnumerator cool_up()
    {
        if (!isrest)
        {
            while (get_skill_cool <= skill_time)
            {
                if (isrest)
                    yield break;
                get_skill_cool += Time.deltaTime%0.001f;
                skill.fillAmount = get_skill_cool / skill_time;
                yield return new WaitForSeconds(0.5f);
            }
            isrest = true;
            get_skill_cool = 0;
            yield break;
        }
    }
 /*   void skill_coolUI()
    {
        see_cool += Time.deltaTime;
        skill.fillAmount += 0;//30초
        //skill.text = "Skill\n" + (int)see_cool;
    }*/
    void skill_readyUI()
    {
        //see_cool = skill_time;
        //skill.text = "Skill\n" +"Ready";
    }
    void player_slider_update()
    {
        slider.value = stamina_useable_time / stamina_useable_time_max;
    }
    public static bool get_ishde() { return ishide; }//숨었는지 확인용
    void player_hide()
    {
       
        if (!ishide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                nowalk();
                noRun();
                play_door_ef();
                Player_rb.velocity = Vector2.zero;
                this.transform.position=new Vector3(cabinet_trs.position.x,transform.position.y,0);
                gameObject.tag = "Untouchable";
                ishide = true;
                // Player_col.enabled = false;
                blind.SetActive(true);
                
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
                //���׹̳� �ۿ� 
                {

                    play_door_ef();
                    speed = nomal_speed;
                    ispenalti = false;
                    stamina_de_time = stamina_de_time_max;
                    usestamina = false;
                    blind.SetActive(false);
                }

            }
        }
    }
    void setRun()
    {
        animator.SetBool("IsRun", true);
        if (run.isPlaying == false)
            run.Play();
    }
    void noRun()
    {
        animator.SetBool("IsRun", false);
        run.Stop();
    }

    void setwalk()
    {
        if (walk.isPlaying == false)
            walk.Play();
        if(run.isPlaying == true)
            walk.Stop();
        animator.SetBool("IsWalk", true);
    }
    void nowalk()
    {
        walk.Stop();
        animator.SetBool("IsWalk", false);
    }
    void player_move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            //방향뒤집기용
            transform.localScale = new Vector3(localscale.x, localscale.y, localscale.z);
            setwalk();
            direction = -1;

            // Player_rb.AddForce(new Vector2(direction * power * speed, 0f));
            transform.Translate(new Vector2(direction * power * speed*Time.deltaTime,0f));
            //  Debug.Log("left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            setwalk();
            //방향뒤집기용
            transform.localScale=new Vector3(localscale.x*-1,localscale.y,localscale.z);
            direction = 1;

            //Player_rb.AddForce(new Vector2(direction * power * speed, 0f));
            transform.Translate(new Vector2(direction * power * speed * Time.deltaTime, 0f));
            //   Debug.Log("right");
        }
        else
        {
            nowalk();
        }
        /*    if (Input.GetKeyUp(KeyCode.A)) ������ �ٵ�� �ҽÿ� velocity�� ���־� ���߱⿡ �̸� ����
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
                
                speed = nomal_speed* stemina_speed ;
                usestamina = true;
                //  Debug.Log(speed);
                setRun();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                
                speed =nomal_speed/stemina_speed ;
                usestamina = false;

                noRun();
                // Debug.Log(speed);
            }
        }

        if (usestamina)
        {
            stamina_useable_time -= Time.deltaTime;
            
            if(stamina_useable_time<0)
            {
                Debug.Log("isp");

                noRun();
                speed = nomal_speed / 2;
                ispenalti = true;
                usestamina = false;
            }
        }
        else if(!ispenalti)//���׹̳��� ������� �ʰ� ���Ƽ ���°� �ƴҰ��
        {
            if (stamina_useable_time < stamina_useable_time_max)
            {
                stamina_useable_time += Time.deltaTime;
            }
        }
        
        if(ispenalti)
        {
          //  Debug.Log(math.abs(Player_rb.velocity.x));
            if (math.abs(Player_rb.velocity.x) >= 2f)
            {
                Player_rb.AddForce(-Player_rb.velocity.normalized * nomal_speed); 
            }
            stamina_de_time -= Time.deltaTime;
            if(stamina_de_time<0)
            {
                speed = nomal_speed/2;
                //Debug.Log("isnotp");
                ispenalti = false;
                stamina_de_time = stamina_de_time_max;
            }
        }
        

    }
    void OnTriggerStay2D(Collider2D other)//��� �浹�ϰ� �����ÿ� �Ͼ
    {
        if (other.CompareTag("Cabinet")) // �浹�� ��ü�� �±װ� "Player"�� ���
        {
            cabinet_trs = other.transform;
            iscan_hide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cabinet")) // �浹�� ��ü�� �±װ� "Player"�� ���
        {
            iscan_hide = false;
        }
    }



}
