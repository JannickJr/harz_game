using _07_Scripts._01_SK_Functions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _07_Scripts._01_SK_Functions
{
    public class Change_Material : MonoBehaviour
    {
        [SerializeField] private GameObject SK_GFX;
        [SerializeField] private Material[] material;
        private Renderer rend;

        private float counter = 0;

        public string layerName;
        private bool collided = false;

        [SerializeField] private GameObject sKNaviStatus;
        [SerializeField] Material[] CrashMaterial;
        [SerializeField] private GameObject Posthalter;

        void Start()
        {
            rend = SK_GFX.GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];

            sKNaviStatus.GetComponent<MeshRenderer>().sharedMaterial = CrashMaterial[0];
            Posthalter.GetComponent<MeshRenderer>().sharedMaterial = material[0];

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainGame"));
            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (layerName == LayerMask.LayerToName(collision.gameObject.layer))
            {
                if (collided == false)
                {
                    if (counter == 0)
                    {
                        rend.sharedMaterial = material[1];
                        counter = 1;


                        sKNaviStatus.GetComponent<MeshRenderer>().sharedMaterial = CrashMaterial[1];
                        Posthalter.GetComponent<MeshRenderer>().sharedMaterial = material[1];
                    }

                    else if (counter == 1)
                    {
                        rend.sharedMaterial = material[2];
                        counter = 2;


                        sKNaviStatus.GetComponent<MeshRenderer>().sharedMaterial = CrashMaterial[2];
                        Posthalter.GetComponent<MeshRenderer>().sharedMaterial = material[2];
                    }

                    else if (counter == 2)
                    {
                        rend.sharedMaterial = material[3];
                        Posthalter.GetComponent<MeshRenderer>().sharedMaterial = material[3];
                        Invoke(nameof(SwitchToMenu), 2F);
                    }
                }
            }
        }

        public void SwitchToMenu()
        {
            Debug.Log("Raum");

            AsyncOperation op = SceneManager.UnloadSceneAsync(2); // muss noch eingestellt werden
            op.completed += (a) =>
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Raum"));
                Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
            };
        }
    }
}
