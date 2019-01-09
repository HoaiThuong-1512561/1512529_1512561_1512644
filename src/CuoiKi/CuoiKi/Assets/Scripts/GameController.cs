using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject panelHelp;

    public GameObject panelNoKey;
    public GameObject panelDie;
    public AudioSource music;
    // Use this for initialization
    void Start () {
        knight_controller.OnNotKey += OnNotKeyHandler;
        knight_controller.GoToMap2 += GoToMap2;
        knight_controller.GoToMap1 += GoToMap1;
        knight_controller.GoToMap3 += GoToMap3;
        knight_controller.GoToMap4 += GoToMenu;
        knight_controller.Die += EndGame;
        knight_controller.ShowPanelHelp += OnClickButtonHelp;
        Data.music = PlayerPrefs.GetInt("music");
        if (Data.music == 1)
        {
            music.Stop();
        }
    }
	public void TurnOnOffMusic()
    {
        if (Data.music == 0)
        {
            Data.music = 1;
            PlayerPrefs.SetInt("music", Data.music);
            music.Stop();
        }
        else
        {
            Data.music = 0;
            PlayerPrefs.SetInt("music", Data.music);
            music.Play();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickButtonHelp()
    {
        if (panelHelp != null)
        {
            panelHelp.SetActive(!panelHelp.activeInHierarchy);
            if (panelHelp.active)
            {
                Data.showPanelHelp = true;
            }
            else
            {
                Data.showPanelHelp = false;
            }
        }
        
    }
    public void OnClickButtonOk()
    {
        if (panelNoKey != null)
        {
            panelNoKey.SetActive(false);
            Data.showPanelHelp = false;
        }
    }

    public void OnNotKeyHandler()
    {
        if (panelNoKey != null)
        {
            panelNoKey.SetActive(true);
            
                Data.showPanelHelp = true;
           
                
            
        }
    }
    public void ExitGame()
    {
        
        Application.Quit();
    }
    public void GoToMap()
    {
        Data.numberAnimal = 15;
        Data.numberSodierDie = 17;
        PlayerInfo.hp = 100;
        Data.showPanelHelp = true;
        Data.firstMap = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ReviewTriNho");
    }
    public void GoToMap1()
    {
        Data.numberAnimal = 15;
        Data.numberSodierDie = 17;
        PlayerInfo.hp = 100;
        Data.showPanelHelp = false;
        Data.firstMap = false;
        PlayerPrefs.SetString("map", "Rung");
        PlayerPrefs.SetInt("bom", PlayerInfo.numberBomb);
        PlayerPrefs.SetInt("trap", PlayerInfo.numberTrap);
        PlayerPrefs.SetFloat("hp", PlayerInfo.hp);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Rung");
    }
    public void GoToMap2()
    {
        Data.showPanelHelp = false;
        Data.firstMap = false;
        PlayerPrefs.SetString("map", "MeCung");
        PlayerPrefs.SetInt("bom", PlayerInfo.numberBomb);
        PlayerPrefs.SetInt("trap", PlayerInfo.numberTrap);
        PlayerPrefs.SetFloat("hp", PlayerInfo.hp);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MeCung");
    }
    public void GoToMap3()
    {
        Data.showPanelHelp = false;
        Data.firstMap = false;
        PlayerPrefs.SetString("map", "LauDai1");
        PlayerPrefs.SetInt("bom", PlayerInfo.numberBomb);
        PlayerPrefs.SetInt("trap", PlayerInfo.numberTrap);
        PlayerPrefs.SetFloat("hp", PlayerInfo.hp);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LauDai1");
    }
    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

    }
    public void LoadGame()
    {
        if (PlayerPrefs.GetString("map") != "")
        {
            Data.showPanelHelp = false;
            Data.firstMap = false;
            PlayerInfo.hp = PlayerPrefs.GetFloat("hp");
            PlayerInfo.numberBomb = PlayerPrefs.GetInt("bom");
            PlayerInfo.numberTrap = PlayerPrefs.GetInt("trap");
            UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("map"));
        }
        else
        {
            Data.showPanelHelp = true;
            Data.firstMap = true;
            Data.numberAnimal = 15;
            Data.numberSodierDie = 17;
            PlayerInfo.hp = 100;
            UnityEngine.SceneManagement.SceneManager.LoadScene("ReviewTriNho");
        }

    }
    public void EndGame()
    {
        if (panelDie != null) {
            panelDie.SetActive(true);
            Data.showPanelHelp = true;
        }
    }
}
