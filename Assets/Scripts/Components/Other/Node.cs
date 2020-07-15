using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    [SerializeField] public string description = null;
    [SerializeField] private Image image = null;
    [SerializeField] private AchievementsPanel achievementsPanel = null;

    public void OnButtonPress()
    {
        achievementsPanel.ShowPanel(description, image, transform.position);
    }

}
