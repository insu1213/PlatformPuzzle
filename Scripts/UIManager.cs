using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Object scene;
    string sceneName;
    public GameObject Clear;
    public GameObject Main;
    public GameObject GameOver = null;
    // Start is called before the first frame update
    void Start() 
    {
        GameOver.gameObject.SetActive(false);
        Clear.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = scene.name;
        
    }

    public void Show_GameOver()
    {
        GameOver.gameObject.SetActive(true);

    }

    public void Show_Clear()
    {
        Clear.gameObject.SetActive(true);

    }

    public void Invisible_Main()
    {
        Main.gameObject.SetActive(false);

    }

    public void OnClick_Retry()
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
        GameObject.Find("Player").GetComponent<CharactorMove>().HP = 4;
    }

    public void OnClick_NextLevel()
    {
        if (sceneName == "Stage1_Scene")
        {
            SceneManager.LoadScene("Stage3_Scene");
        }
        else if (sceneName == "Stage2_Scene")
        {
            SceneManager.LoadScene("Stage3_Scene");
        }
        else if (sceneName == "Stage3_Scene")
        {
            SceneManager.LoadScene("Stage4_Scene");
        }
        else if (sceneName == "Stage4_Scene") 
        {
            SceneManager.LoadScene("Stage5_Scene");
        } 
        else if(sceneName == "Stage5_Scene") // 게임 종료
        {
            
        }
        else
        {
            Debug.Log("(UIManager.cs) LoadScene 오류 발생");
        }
    }
}
