using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;

namespace _09_Scripts._Dialogsystem
{
    public class Dialog_2 : MonoBehaviour
    {
        #region
        public TextMeshProUGUI textComponent;
        public TextMeshProUGUI textName;
        public GameObject imageRuma;
        public GameObject imageKobold_1;
        public GameObject imageKobold_2;

        //---Material Change---//
        public Image imageChangeRuma;
        public List<Sprite> spriteChoicesRuma_1;
        public List<Sprite> spriteChoicesRuma_2;
        public Sprite RumaSpeechbubble;
        public Sprite RumaSpeechbubbleA;
        public Sprite RumaSpeechbubbleB;

        public Image imageChangeKobold;
        public List<Sprite> spriteChoicesKobold;
        public Sprite KoboldASpeechbubble;
        public Sprite KoboldBSpeechbubble;

        //public Image imageChangeKoboldB;
        //public List<Sprite> spriteChoicesKoboldB;


        //---Text---//
        public string[] lines;
        public float textSpeed;

        private int index;
        private bool cutScene_1IsActive = false;

        public string[] lines2;
        private bool cutScene_2IsActive = false;
        public static bool LevelStarted = true; // als Methode schreiben

        private bool speechbubbleKoboldIsActive = false;
        private bool end = false;

        //---HUD Deactivation---//
        public static event Action OnHUDActivation;
        public static event Action OnHUDDeactivation;


        private GameObject character;

        public GameObject wall;

        public Camera mainCamera;
        public Camera cameraDialog;

        //public static event Action OnInteraction; // gescheitertes Experiment für Itemslot // Test für Truhencollider funktionierte, ist aber unnötig
        public static event Action OnLoadScene;
        public static event Action OnRing; // Ring zerstört sich
        [SerializeField] private GameObject Button;
        #endregion

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
            cameraDialog.enabled = true;
            mainCamera.enabled = false;
            StartCutscene_1();
        }

        void Update()
        {
            //---Sprechblasen---// --> Muss vor "Dialog weiter"-Methoden stehen!
            TextStart();
            //---Dialog 1 weiter---//
            if (cutScene_1IsActive == true && LevelStarted == true)
            {
                Next();
                CharacterChange();
            }
            //---Dialog 2 weiter---//
            if (cutScene_2IsActive == true)
            {
                Next2();
                CharacterChange2();
            }
        }

        //---DIALOG 1---//
        public void StartCutscene_1() // Dialog 1 - Verweis auf startende Methode
        {
            Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
            textComponent.text = string.Empty;
            imageRuma.SetActive(true);
            imageChangeRuma.enabled = true;
            imageKobold_1.SetActive(true);
            imageChangeKobold.enabled = true;
            imageKobold_2.SetActive(false);
            //imageKobold_2.SetActive(true);
            //imageChangeKoboldB.enabled = false;
            //--- R + R können nicht angeklickt werden ---// --> braucht man nicht mehr wegen Wall
            /*character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = false;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = false;*/
            //---HUD Deactivation---//
            OnHUDDeactivation();
            //---Wall---///
            wall.SetActive(true);
            cutScene_1IsActive = true; // cutScene_1IsActive = true; --> evtl. zu Methode ändern
            StartDialog();
        }

        void StartDialog() // Dialog 1 - Start 
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine() // Dialog 1 - Text wird in einzelnen Buchstaben wiedergegeben
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine() // Dialog 1 - Sprung in nächste Textzeile bei Klick oder Schluss
        {
            if (index < lines.Length - 1)
            {
                index++;
                Debug.Log(index);
                textComponent.text = string.Empty;
                imageChangeRuma.sprite = spriteChoicesRuma_1[index];
                imageChangeKobold.sprite = spriteChoicesKobold[index];
                //imageChangeKoboldB.sprite = spriteChoicesKoboldB[index];
                StartCoroutine(TypeLine());
            }
            else  // kein Dialogfeld mehr vorhanden
            {
                mainCamera.enabled = true;
                cameraDialog.enabled = false;
                gameObject.SetActive(false);
                DialogActivation.dialogActivated = false;
                DialogActivation.characterNumber = 0;
                //index = 0; // im Moment nicht mehr notwendig, aber zur Sicherheit mal noch deaktiviert im Code lassen; war auf -1
                //---HUD Activation---////---Aufgabenaktivierung---//
                OnHUDActivation();
                //---Wall---///
                wall.SetActive(false);
                //---Script Activation---// --> braucht man nicht mehr wegen Wall
                /*character = GameObject.Find("Character_Romar");
                character.GetComponent<DialogActivation>().enabled = true;
                character = GameObject.Find("Character_Ruma");
                character.GetComponent<DialogActivation>().enabled = true;*/
                cutScene_1IsActive = false; // cutScene_1IsActive = false; --> evtl. zu Methode ändern
                LevelStarted = false; // LevelStarted = false; --> evtl. zu Methode ändern
                                      //OnInteraction(); // gescheitertes Experiment // neuer Test funktionierte für Truhe
            }
        }

        public void Next() // Dialog 1 - Verweis auf Methode mit Sprung in nächste Textzeile bei Klick
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

        public void CharacterChange() // Dialog 1 - Textboxanhänge verändern sich
        {
            switch (index)
            {
                case 0:
                case 2:
                case 4:
                case 5:
                case 9:
                case 10:
                case 11:
                    //imageRuma.SetActive(true);
                    //imageKobold_1.SetActive(false);
                    //imageKobold_2.SetActive(false);
                    imageChangeRuma.enabled = true;
                    imageChangeKobold.enabled = true;
                    textName.text = "Ruma";
                    break;
                case 1:
                case 8:
                    //imageRuma.SetActive(false);
                    //imageKobold_1.SetActive(true);
                    //imageKobold_2.SetActive(false);
                    textName.text = "Kobold 1";
                    break;
                case 3:
                case 6:
                case 7:
                    //imageRuma.SetActive(false);
                    //imageKobold_1.SetActive(false);
                    //imageKobold_2.SetActive(true);
                    textName.text = "Kobold 2";
                    break;
                default:
                    break;
            }
        }

        //---DIALOG 2---//
        /*public void Victory()
        {
            StartCutscene_2();
            Debug.Log("Start2");
        }*/
        public void Dialog2Continue()
        {

        }

        private void OnEnable() // Start Dialog 2 nach Rätsellösung
        {
            cameraDialog.enabled = true;
            mainCamera.enabled = false;
            if (LevelStarted == false && Puzzle1_LockControl.victory == true) // evtl. zu Methode ändern
            {
                StartCutscene_2();
                Debug.Log("Start2");
            }
            else
            {
                return;
            }
        }

        public void StartCutscene_2() // Dialog 2 - Verweis auf startende Methode
        {
            Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
            textComponent.text = string.Empty;
            imageRuma.SetActive(true);
            imageChangeRuma.enabled = true;
            //--- R + R können nicht angeklickt werden --- --> braucht man nicht mehr wegen Wall
            /*character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = false;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = false;*/
            //---HUD Deactivation---//
            OnHUDDeactivation();
            //---Wall---///
            wall.SetActive(true);
            cutScene_2IsActive = true; // --> evtl.zu Methode ändern
            StartDialog2();
        }
        void StartDialog2() // Dialog 2 - Start 
        {
            index = 0;
            imageChangeRuma.sprite = spriteChoicesRuma_2[index];
            StartCoroutine(TypeLine2());
        }

        IEnumerator TypeLine2() // Dialog 2 - Text wird in einzelnen Buchstaben wiedergegeben
        {
            foreach (char c in lines2[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine2() // Dialog 2 - Sprung in nächste Textzeile bei Klick oder Schluss
        {
            if (index < lines2.Length - 1)
            {
                index++;
                Debug.Log(index);
                textComponent.text = string.Empty;
                imageChangeRuma.sprite = spriteChoicesRuma_2[index];
                StartCoroutine(TypeLine2());
            }
            else // kein Dialogfeld mehr vorhanden
            {
                gameObject.SetActive(false);
                cameraDialog.enabled = false;
                mainCamera.enabled = true;
                Button.SetActive(true);
                OnRing(); // Ring zerstört sich
                OnHUDActivation();
                OnLoadScene();
                Debug.Log("weiter");
            }
        }

        public void Next2() // Dialog 2 - Verweis auf Methode mit Sprung in nächste Textzeile bei Klick
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines2[index])
                {
                    NextLine2();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines2[index];
                }
            }
        }

        public void CharacterChange2() // Dialog 2 - Textboxanhänge verändern sich
        {
            switch (index)
            {
                case 0:
                case 1:
                    imageRuma.SetActive(true);
                    imageChangeRuma.enabled = true;
                    //imageKobold_1.SetActive(false);
                    //imageKobold_2.SetActive(false);
                    textName.text = "Ruma";
                    break;
                default:
                    break;
            }
        }

        //---SPRECHBLASEN---//
        public void TextStart() // Sprechblasen - Start
        {
            //---HUD Deactivation---//
            OnHUDDeactivation();
            if (DialogActivation.characterNumber == 1)
            {
                imageRuma.SetActive(true);
                imageChangeRuma.enabled = true;
                imageChangeRuma.sprite = RumaSpeechbubble;
                textName.text = "Ruma";
                // hier davor evtl. int wechseln, für anderen Text; aber nur in andere(r) Szene
                textComponent.text = "Was soll ich nur tun? Wenn es doch nur einen Ausweg aus dieser finsteren Höhle gäbe….";
                imageKobold_1.SetActive(false);
                character = GameObject.Find("Character_Kobold_1");
                character.GetComponent<DialogActivation>().enabled = false;
                imageKobold_2.SetActive(false);
                character = GameObject.Find("Character_Kobold_2");
                character.GetComponent<DialogActivation>().enabled = false;
                if (Input.GetMouseButtonDown(0))
                {
                    End();
                }
            }
            if (DialogActivation.characterNumber == 2)
            {
                if (speechbubbleKoboldIsActive == false)
                {
                    imageKobold_1.SetActive(true);
                    imageChangeKobold.enabled = true;
                    imageChangeKobold.sprite = KoboldASpeechbubble;
                    imageRuma.SetActive(true);
                    imageChangeRuma.enabled = true;
                    imageChangeRuma.sprite = RumaSpeechbubble;
                    textName.text = "Kobold 1";
                    textComponent.text = "Denk gar nicht erst daran, zu fliehen! Unsere Speere sind geschärft und wir werden sie benutzen!";
                    //imageRuma.SetActive(false);
                    character = GameObject.Find("Character_Ruma");
                    imageKobold_2.SetActive(false);
                    character = GameObject.Find("Character_Kobold_2");
                }
                if (speechbubbleKoboldIsActive == true)
                {
                    //imageRuma.SetActive(true);
                    textName.text = "Ruma";
                    textComponent.text = "Fieslinge! Kennt ihr denn gar kein Erbarmen?";
                    //imageKobold_1.SetActive(false);
                    character = GameObject.Find("Character_Kobold_1");
                    //imageKobold_2.SetActive(false);
                    character = GameObject.Find("Character_Kobold_2");
                    end = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (speechbubbleKoboldIsActive == false)
                    {
                        speechbubbleKoboldIsActive = true;
                        Debug.Log("speechbubbleRomarIsActive: " + speechbubbleKoboldIsActive);
                    }
                    if (end == true)
                    {
                        speechbubbleKoboldIsActive = false;
                        end = false;
                        Debug.Log("speechbubbleRomarIsActive: " + speechbubbleKoboldIsActive);
                        End();
                    }
                }
            }
            if (DialogActivation.characterNumber == 3)
            {
                if (speechbubbleKoboldIsActive == false)
                {
                    imageKobold_2.SetActive(true);
                    imageChangeKobold.enabled = true;
                    imageChangeKobold.sprite = KoboldBSpeechbubble;
                    imageRuma.SetActive(true);
                    imageChangeRuma.enabled = true;
                    imageChangeRuma.sprite = RumaSpeechbubble;
                    textName.text = "Kobold 2";
                    textComponent.text = "Ihr seid genau so hübsch wie man sich erzählt, Prinzessin.";
                    //imageRuma.SetActive(false);
                    character = GameObject.Find("Character_Ruma");
                    imageKobold_1.SetActive(false);
                    character = GameObject.Find("Character_Kobold_1");
                }
                if (speechbubbleKoboldIsActive == true)
                {
                    //imageRuma.SetActive(true);
                    textName.text = "Ruma";
                    textComponent.text = "Schweig still! Nur mein lieber Romar darf diese Worte zu mir sagen.";
                    //imageKobold_1.SetActive(false);
                    character = GameObject.Find("Character_Kobold_1");
                    //imageKobold_2.SetActive(false);
                    character = GameObject.Find("Character_Kobold_2");
                    end = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (speechbubbleKoboldIsActive == false)
                    {
                        speechbubbleKoboldIsActive = true;
                        Debug.Log("speechbubbleRomarIsActive: " + speechbubbleKoboldIsActive);
                    }
                    if (end == true)
                    {
                        speechbubbleKoboldIsActive = false;
                        end = false;
                        Debug.Log("speechbubbleRomarIsActive: " + speechbubbleKoboldIsActive);
                        End();
                    }
                }
            }
        }

        public void End() // Sprechblasen - Ende
        {
            mainCamera.enabled = true;
            cameraDialog.enabled = false;
            gameObject.SetActive(false);
            imageKobold_1.SetActive(false);
            imageKobold_2.SetActive(false);
            imageChangeKobold.enabled = false;
            imageRuma.SetActive(false);
            imageChangeRuma.enabled = false;
            DialogActivation.dialogActivated = false;
            DialogActivation.characterNumber = 0;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = true;
            character = GameObject.Find("Character_Kobold_1");
            character.GetComponent<DialogActivation>().enabled = true;
            character = GameObject.Find("Character_Kobold_2");
            character.GetComponent<DialogActivation>().enabled = true;
            //---HUD Activation---//
            OnHUDActivation();
        }
    }
}
