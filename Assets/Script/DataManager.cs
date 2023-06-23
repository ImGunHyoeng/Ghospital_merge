using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//데이터를 넣거나 가져옴
//저장하는 방법
//1. 저장할 데이터가 존재
//2. 데이터를 제이슨으로 변환
//3. 제이슨을 외부에 저장

//불러오는 방법
//1. 외부에 저장된 제이슨을 가져옴
//2. 제이슨을 데이터형태로 변환
//3. 불러온 데이터를 사용

//슬롯별로 다르게 저장

public class DataManager : MonoBehaviour
{
    public string path;
    public int nowSlot;
    static bool iswrite_start=false;
    //싱글톤
    public static DataManager instance;
    // Start is called before the first frame update
    public Player_Data playerData=new Player_Data();// Player_Data();
    private void Awake()
    {
        #region 싱글톤//해당하는공간 나타내기
         if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);//하나를 만들어야한다.아니라면 삭제
        }
        #endregion  
        path = Application.persistentDataPath+ "/player_data";//유니티에서 제공해주는 파일
        
    }

    private void Start()
    {
        string data=JsonUtility.ToJson(playerData);
        //print(path);
        
            File.WriteAllText(path + nowSlot, data);//path+filename을 한다면은 파일의 저장공간과 파일의 이름까지 지정이 가능하다.
        //    iswrite_start = true;
        
        //print(data);
    }
    public void SaveData()
    {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path +nowSlot.ToString(), data);//path+filename을 한다면은 파일의 저장공간과 파일의 이름까지 지정이 가능하다.
        //filename을 변경해서 해당하는공간에 접근하는것도 가능하다.
    }
    public void LoadData()
    {
        //이렇게 하면은 세이브 슬롯의 값도 바뀜
        string data=File.ReadAllText(path +nowSlot.ToString());//json을 저장했으니 json상태
        playerData=JsonUtility.FromJson<Player_Data>(data);//플레이어 데이터가 덮혀씌어진다.

    }
 /*   public void DataClear()
    {
        nowSlot = -1;
        playerData=new Player_Data();
    }*/
}
