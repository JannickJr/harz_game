using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

namespace _09_Scripts._Dialogsystem
{
    public class Dialog : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public TextMeshProUGUI textName; 
        public GameObject imageRuma;
        public GameObject imageRomar;
        public string[] lines;
        public float textSpeed;

        private int index;
        private bool cutScene_1IsActive = false;

        public string[] lines2;
        private bool cutScene_2IsActive = false;
        public static bool LevelStarted = true;

        #region //---HUD Deactivation---//
        [SerializeField] private GameObject Slider;
        [SerializeField] private GameObject IS;
        [SerializeField] private GameObject ISD;
        [SerializeField] private GameObject IB;
        [SerializeField] private GameObject MB;
        [SerializeField] private GameObject A1;
        [SerializeField] private GameObject A2;
        [SerializeField] private GameObject A2Panel;
        #endregion

        private GameObject character;

        private void Awake()
        {
            //---Dialog 2 Start---//
            if (LevelStarted == false) // die muss irgendwie ausgeführt werden
            {
                StartCutscene_2();
                Debug.Log("Start2");
            }
        }

        #region //---INFO---//
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
        #endregion

        void Start()
        {
            StartCutscene_1();
            /*if (LevelStarted == true)
            {
                StartCutscene_1();
            }
            if (LevelStarted == false)
            {
                StartCutscene_2();
            }*/
            Debug.Log("cutScene_1IsActive: " + cutScene_1IsActive);
            Debug.Log("cutScene_2IsActive: " + cutScene_2IsActive);
        }
        
        void Update() 
        {
            //---HUD Deactivation---//
            Slider.SetActive(false);
            IS.SetActive(false);
            ISD.SetActive(false);
            IB.SetActive(false);
            MB.SetActive(false);
            //---Sprechblasen---// --> Muss vor "Dialog weiter"-Methoden stehen!
            TextStart();
            //---Dialog weiter---//
            if (cutScene_1IsActive == true && LevelStarted == true)
            {
                Next();
                CharacterChange();
            }
            //---Dialog 2 Start---//
            if (cutScene_2IsActive == true)
            {
                Next2();
                CharacterChange2();
            }
        }

        //---DIALOG 1---//
        public void StartCutscene_1() // Cutscene 1 - Verweis auf startende Methode
        {
            Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
            textComponent.text = string.Empty;
            //--- R + R können nicht angeklickt werden ---
            character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = false;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = false;
            cutScene_1IsActive = true;
            StartDialog();
        }

        void StartDialog() // Cutscene 1 - Start Cutscene 1
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine() // Cutscene 1 - Text wird in einzelnen Buchstaben wiedergegeben
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine() // Cutscene 1 - Sprung in nächste Textzeile bei Klick oder Schluss
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
                DialogActivation.characterNumber = 0;
                //index = 0; // im Moment nicht mehr notwendig, aber zur Sicherheit mal noch deaktiviert im Code lassen; war auf -1
                //---HUD Activation---//
                Slider.SetActive(true);
                //IS.SetActive(true);
                //ISD.SetActive(true);
                IB.SetActive(true);
                MB.SetActive(true);
                //---Script Activation---//
                character = GameObject.Find("Character_Romar");
                character.GetComponent<DialogActivation>().enabled = true;
                character = GameObject.Find("Character_Ruma");
                character.GetComponent<DialogActivation>().enabled = true;
                cutScene_1IsActive = false;
                //---Aufgabenaktivierung---//
                A1.SetActive(true);
                A2Panel.SetActive(true);
                A2.SetActive(true);
            }
        }

        public void Next() // Cutscene 1 - Verweis auf Methode mit Sprung in nächste Textzeile bei Klick
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

        public void CharacterChange() // Cutscene 1 - Textboxanhänge verändern sich
        {
            switch (index)
            {
                case 0:
                case 3:
                case 5:
                case 6:
                    imageRuma.SetActive(false);
                    imageRomar.SetActive(true);
                    textName.text = "Romar";
                    break;
                case 1:
                case 2:
                case 4:
                    imageRuma.SetActive(true);
                    imageRomar.SetActive(false);
                    textName.text = "Ruma";
                    break;
                default:
                    break;
            }
        }

        //---DIALOG 2---//
        public void StartCutscene_2() // Cutscene 1 - Verweis auf startende Methode
        {
            Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
            textComponent.text = string.Empty;
            //--- R + R können nicht angeklickt werden ---
            character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = false;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = false;
            cutScene_2IsActive = true;
            StartDialog2();
        }
        void StartDialog2() // Cutscene 1 - Start Cutscene 1
        {
            index = 0;
            StartCoroutine(TypeLine2());
        }

        IEnumerator TypeLine2() // Cutscene 1 - Text wird in einzelnen Buchstaben wiedergegeben
        {
            foreach (char c in lines2[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine2() // Cutscene 1 - Sprung in nächste Textzeile bei Klick oder Schluss
        {
            if (index < lines2.Length - 1)
            {
                index++;
                Debug.Log(index);
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine2());
            }
            else
            {
                gameObject.SetActive(false);
                DialogActivation.dialogActivated = false;
                DialogActivation.characterNumber = 0;
                //index = -1; // im Moment nicht mehr notwendig, aber zur Sicherheit mal noch deaktiviert im Code lassen
                //---HUD Activation---//
                Slider.SetActive(true);
                //IS.SetActive(true);
                //ISD.SetActive(true);
                IB.SetActive(true);
                MB.SetActive(true);
                //---Script Activation---//
                character = GameObject.Find("Character_Romar");
                character.GetComponent<DialogActivation>().enabled = true;
                character = GameObject.Find("Character_Ruma");
                character.GetComponent<DialogActivation>().enabled = true;
                cutScene_2IsActive = false;
                //---Aufgabenaktivierung---//
                //A1.SetActive(true);
                //A2Panel.SetActive(true);
                //A2.SetActive(true);
                SceneManager.LoadScene("04_CutScene_2");
            }
        }

        public void Next2() // Cutscene 1 - Verweis auf Methode mit Sprung in nächste Textzeile bei Klick
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine2();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }

        public void CharacterChange2() // Cutscene 1 - Textboxanhänge verändern sich
        {
            switch (index)
            {
                case 1:
                case 2:
                case 5:
                case 7:
                    imageRuma.SetActive(false);
                    imageRomar.SetActive(true);
                    textName.text = "Romar";
                    break;
                case 0:
                case 3:
                case 4:
                case 6:
                    imageRuma.SetActive(true);
                    imageRomar.SetActive(false);
                    textName.text = "Ruma";
                    break;
                default:
                    break;
            }
        }

        //---SPRECHBLASEN---//
        public void TextStart() // Sprechblasen - Start
        {
            if (DialogActivation.characterNumber == 1)
            {
                imageRuma.SetActive(true);
                textName.text = "Ruma";
                // hier davor evtl. int wechseln, für anderen Text; aber nur in andere Szene
                textComponent.text = "Ein Geschenk möchtest du mir geben? Oh Romar, du bist so gut zu mir!";
                imageRomar.SetActive(false);
                character = GameObject.Find("Character_Romar"); 
                character.GetComponent<DialogActivation>().enabled = false;
                if (Input.GetMouseButtonDown(0))
                {
                    End();
                }
            }
            if (DialogActivation.characterNumber == 2)
            {
                imageRomar.SetActive(true);
                textName.text = "Romar";
                textComponent.text = "Das Geschenk für Ruma liegt hier irgendwo verborgen. Wenn ich doch bloß wüsste, wo ich es ließ ….";
                imageRuma.SetActive(false);
                character = GameObject.Find("Character_Ruma");
                character.GetComponent<DialogActivation>().enabled = false;
                if (Input.GetMouseButtonDown(0))
                {
                    End();
                }
            }
        }

        public void End() // Sprechblasen - Ende
        {
            gameObject.SetActive(false);
            imageRuma.SetActive(false);
            imageRomar.SetActive(false);
            DialogActivation.dialogActivated = false;
            DialogActivation.characterNumber = 0;
            character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = true;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = true; 
            //---HUD Activation---//
            Slider.SetActive(true);
            IB.SetActive(true);
            MB.SetActive(true);
            //IS.SetActive(true);
            //ISD.SetActive(true);
        }
    }
}
