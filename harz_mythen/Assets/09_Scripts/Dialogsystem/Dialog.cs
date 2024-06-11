using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textName; // neu
    public GameObject imageRuma;
    public GameObject imageRomar;
    public string[] lines;
    public float textSpeed;

    private int index;

    //public static float valueText;

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
    */
    
    void Start()
    {
        ///if (valueText == 1)
        {
            //Debug.Log("valueText = " + valueText);
            if (index == 0)
            {
                textComponent.text = string.Empty;
                StartDialog();
            }
        }
        
    }

    void Update()
    {
        Start_2(); // neu
        Next();
        CharacterChange(); // neu
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
            index = -1; // neu

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
