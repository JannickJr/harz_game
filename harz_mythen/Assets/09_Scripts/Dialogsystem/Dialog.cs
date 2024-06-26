using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace _09_Scripts._Dialogsystem
{
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textName; // neu
    public GameObject imageRuma;
    public GameObject imageRomar;
    public string[] lines;
    public float textSpeed;

    private int index;

    //---HUD Deactivation---//
    [SerializeField] private GameObject Slider;
    [SerializeField] private GameObject IS;
    [SerializeField] private GameObject ISD;
    [SerializeField] private GameObject IB;
    [SerializeField] private GameObject MB;

    public static int valueText = 0;
    public static bool isdriving = false; // neu Test

    //---INFO---//
    /* Nachricht schicken mit GetComponent oder FindComponent oder int, 
    um in diesem Script jeweils auch Charakternamen und -Bild zu triggern.
    Materialchange, Textänderung, z.B. mit int-Änderung --> 1 Ruma, 2 Romar 
    bzw. so viele Namen und Materials, wie es Wechsel in Sprecherrolle gibt.
    Oder in Update auch Funktion zu oben Genanntem reinschreiben und dort sagen, wenn index = 0, = 1, = 2,
    Hilfe siehe Seifenkiste
    Später muss noch abgefragt werden, von wem die Nachricht zur Aktivierung kam. Um die richtigen Texte zu triggern.
    leichtere Alternative: lauter einzelne Dialogscripte.
    SetActive nutzen für ImageSprites
    Script.static quasi
    */

    void Start()
    {
        //if (valueText == 0)
        //if (DialogActivation.characterNumber == 0)
        {
                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
            //Debug.Log("valueText = " + valueText);
            if (index == 0)
            {
                textComponent.text = string.Empty;
                StartDialog();
                isdriving = false; // neu Test
            }
        } 
    }

    void Update()
    {
        //---HUD Deactivation---//
        Slider.SetActive(false);
        IS.SetActive(false);
        ISD.SetActive(false);
        IB.SetActive(false);
        MB.SetActive(false);
        //---Dialog weiter---///
        Start_2(); // neu
        Next();
        CharacterChange(); // neu
        isdriving = true; // neu Test
    }

    public void Start_2() // neu
    {
            if (index == -1)
            {
                textComponent.text = string.Empty;
                StartDialog();
            }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            Debug.Log(index);
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            DialogActivation.dialogActivated = false;
            index = -1; // neu
            //---HUD Activation---//
            Slider.SetActive(true);
            //IS.SetActive(true);
            //ISD.SetActive(true);
            IB.SetActive(true);
            MB.SetActive(true);
        }
    }

    public void Next()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void CharacterChange()
    {
        switch (index)
        {
            case 0: 
                imageRomar.SetActive(true);
                imageRuma.SetActive(false);
                textName.text = "Romar";
                break;
            case 1: case 2:
                imageRuma.SetActive(true);
                imageRomar.SetActive(false);
                textName.text = "Ruma";
                break;
            default:
                break;
        }
    }
}
}
