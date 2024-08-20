using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpTexts : MonoBehaviour
{
    [SerializeField] private TMP_Text help_1;
    [SerializeField] private TMP_Text help_2;
    [SerializeField] private TMP_Text solution;

    public void OnEnable()
    {
        //HelpVoting();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void HelpVoting()
    {
        if (GameObject.Find("03_Scene_01"))
        {
            help_1.text = "Die Truhe ist tief im Wald versteckt.";
            help_2.text = "Wie oft findest du die Farben auf den Zahn-\nrädern auf den Blumen wieder?";
            solution.text = "weiß: 1 \nlila: 5 \ngelb: 4 \nrot: 0";
        } 
        if (GameObject.Find("05_Scene_02"))
        {
            help_1.text = "Die Kristalle bergen eine magische Kraft.";
            help_2.text = "Die Kristalle müssen in der Reihenfolge der Melodie angeklickt werden.";
            solution.text = "...";
        }
        if (GameObject.Find("07_Scene_03"))
        {
            help_1.text = "Die Sterne leuchten ganz hell.";
            help_2.text = "noch unbekannt";
            solution.text = "...";
        }
    }

}
