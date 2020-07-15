using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance = null;

    [SerializeField] public List<Sprite> Backgrounds = null;
    [SerializeField] public List<Sprite> Characters = null;
    [SerializeField] public List<VideoClip> Video = null;
    [SerializeField] public List<string> Tips = null;
    [SerializeField] public List<GameObject> Photo = null;
    [SerializeField] public List<AudioClip> Audio = null;

    private void Awake()
    {
        Instance = this;
    }

}
