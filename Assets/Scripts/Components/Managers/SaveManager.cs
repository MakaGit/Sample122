using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UnlockedChapter", 1);
        PlayerPrefs.Save();
    }

    public int GetCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
    }

    public void SaveProgress(string save)
    {
        PlayerPrefs.SetString("Progress", save);
        PlayerPrefs.Save();
    }

    public void DeleteChapterProgress()
    {
        PlayerPrefs.DeleteKey("Progress");

        PlayerPrefs.DeleteKey("Background");

        PlayerPrefs.DeleteKey("Music");

        PlayerPrefs.DeleteKey("LeftCharacterIndex");
        PlayerPrefs.DeleteKey("LeftCharacterName");

        PlayerPrefs.DeleteKey("RightCharacterIndex");
        PlayerPrefs.DeleteKey("RightCharacterName");
    }

    public void UnlockNextChapter()
    {
        int chapter = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("UnlockedChapter", ++chapter);
        PlayerPrefs.Save();
    }

    public int LoadUnlockedChapter()
    {
        int ch = PlayerPrefs.GetInt("UnlockedChapter");
        return ch;
    }

    public string LoadProgress()
    {
        string save = PlayerPrefs.GetString("Progress");
        return save;
    }

    public void SavePointsEndOfChapter(string name, int variable)
    {
        PlayerPrefs.SetInt(name + GetCurrentScene(), variable);
        PlayerPrefs.DeleteKey(name);
        PlayerPrefs.Save();
    }

    public int LoadPointsForNewChapter(string name)
    {
        int points = 0;
        if (GetCurrentScene() <= 1)
        {
            return points;
        }
        else
        {
            for (int i = 1; i < GetCurrentScene(); i++)
            {
                points += PlayerPrefs.GetInt(name + i);
            }
            return points;
        }
    }

    public void SaveBackground(string tag)
    {
        PlayerPrefs.SetString("Background", tag);
        PlayerPrefs.Save();
    }

    public string LoadBackground()
    {
        string save = PlayerPrefs.GetString("Background");
        return save;
    }

    public void SaveLeftCharacter(int index, string name)
    {
        PlayerPrefs.SetInt("LeftCharacterIndex", index);
        PlayerPrefs.SetString("LeftCharacterName", name);
        PlayerPrefs.Save();
    }
    public int LoadLeftCharacterIndex()
    {
        int save = PlayerPrefs.GetInt("LeftCharacterIndex");
        return save;
    }
    public string LoadLeftCharacterName()
    {
        string save = PlayerPrefs.GetString("LeftCharacterName");
        return save;
    }

    public void SaveRightCharacter(int index, string name)
    {
        PlayerPrefs.SetInt("RightCharacterIndex", index);
        PlayerPrefs.SetString("RightCharacterName", name);
        PlayerPrefs.Save();
    }
    public int LoadRightCharacterIndex()
    {
        int save = PlayerPrefs.GetInt("RightCharacterIndex");
        return save;
    }
    public string LoadRightCharacterName()
    {
        string save = PlayerPrefs.GetString("RightCharacterName");
        return save;
    }
    public void SaveMusic(int index)
    {
        PlayerPrefs.SetInt("Music", index);
        PlayerPrefs.Save();
    }

    public int LoadMusic()
    {
        int save = PlayerPrefs.GetInt("Music");
        return save;
    }

    public void LoadAchievementsForNewChapter(int index)
    {
        switch(index)
        {
            case 1:
                PlayerPrefs.DeleteKey("Node1");
                PlayerPrefs.DeleteKey("Node2");
                PlayerPrefs.DeleteKey("Node3");
                PlayerPrefs.DeleteKey("Node4");
                PlayerPrefs.DeleteKey("Node5");
                PlayerPrefs.DeleteKey("Node6");
                PlayerPrefs.DeleteKey("Node7");
                PlayerPrefs.DeleteKey("Node8");
                PlayerPrefs.DeleteKey("Node9");
                PlayerPrefs.DeleteKey("Node10");
                PlayerPrefs.DeleteKey("Node11");
                PlayerPrefs.DeleteKey("Node12");
                goto case 2;

            case 2:
                PlayerPrefs.DeleteKey("Node13");
                PlayerPrefs.DeleteKey("Node14");
                goto case 3;

            case 3:
                PlayerPrefs.DeleteKey("Node15");
                PlayerPrefs.DeleteKey("Node16");
                PlayerPrefs.DeleteKey("Node17");
                PlayerPrefs.DeleteKey("Node18");
                PlayerPrefs.DeleteKey("Node19");
                PlayerPrefs.Save();
                break;

            default:
                throw new Exception("Incorrect index in save switсh : " + index);
        }
    }

    public void SetAchievement(int index)
    {
        PlayerPrefs.SetInt("Node" + index, 1);
        PlayerPrefs.Save();
    }
}
