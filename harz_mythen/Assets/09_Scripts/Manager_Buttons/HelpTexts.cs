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
            help_2.text = "Die Farben auf den Zahnrädern stehen in Zusammenhang mit den Blumen im Wald."; // Wie oft findest du die Farben auf den Zahn-\nrädern auf den Blumen wieder?
            solution.text = "weiß: 2 \nlila: 2 \ngelb: 2 \nblau: 4";
        } 
        if (GameObject.Find("05_Scene_02"))
        {
            help_1.text = "Die Kristalle bergen eine magische Kraft.";
            help_2.text = "Sie müssen in der richtigen Reihenfolge angeklickt werden.";
            solution.text = "Die richtige Reihenfolge steht auf dem Wagen.";
        }
        if (GameObject.Find("07_Scene_03"))
        {
            help_1.text = "Die Sterne leuchten ganz hell.";
            help_2.text = "Die Sterne müssen in die richtige Form geschoben werden.";
            solution.text = "...";
        }
    }

}
