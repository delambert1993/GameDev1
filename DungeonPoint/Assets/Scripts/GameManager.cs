namespace Game
{
    using UnityEngine;
    using Controllers;
    using Entitys.Player;

    public class GameManager : MonoBehaviour
    { 
        #region singleton
        static private GameManager _instance;
        static public GameManager instance
        {
            get
            {
                //Si es la primera vez que accedemos a la instancia
                //si no existe, la creamos
                if (_instance == null)
                {
                    //Creamos un nuevo objeto llamado "_GameManager"
                    GameObject go = new GameObject("_GameManager");
                    // anadimos el script "GameManager" al objeto
                    go.AddComponent<GameManager>();
                    //guardamos en la instancia el objeto creado
                    _instance = go.GetComponent<GameManager>();
                    //hacemos que el objeto no se elimine al cambiar de escena
                    DontDestroyOnLoad(go);
                }
                //devolvemos la instancia
                return _instance;
            }
        }
        #endregion
        public CameraController cam;        
        public PlayerController player;
        public PrefabSpawner spawn;
        // Start is called before the first frame update
        void Start()
        {
            this.cam = FindObjectOfType<CameraController>();            
            this.player = FindObjectOfType<PlayerController>();
            cam.SetTarget(player.gameObject.transform);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
