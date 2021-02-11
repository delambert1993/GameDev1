using UnityEngine;
using UnityEngine.AI;

namespace Game.Controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavController : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameManager _manager;
        public GameManager manager { get => _manager; private set => _manager = value; }
        private NavMeshAgent _nav;
        public NavMeshAgent nav { get => _nav; private set => _nav = value; }

        private bool _isRunning;
        public bool isRunning { get => _isRunning; set => _isRunning = value; }
        #endregion

        #region Main Methods
        private void Start()
        {
            InitialiceClass();
        }
        private void Update()
        {
            ClickAndMove();
        }
        #endregion
        #region HelperMetods
        private void InitialiceClass()
        {
            //Inicializamos los valores al empezar
            this.nav = this.GetComponent<NavMeshAgent>();
            this.manager = FindObjectOfType<GameManager>();
            
            this.isRunning = false;
        }

        private void ClickAndMove()
        {
            //Mover el jugador hacia la posicion del raton cuando
            //el boton del mouse es activado
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = manager.cam.cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 100))
                {
                    this.nav.destination = hitInfo.point;
                }
            }//Si el camino que falta es menor a la distancia final dejara de moverse
            if(nav.remainingDistance <= nav.stoppingDistance)
            {
                isRunning = false;
            }//Sino continuara hasta llegar
            else
            {
                isRunning = true;
            }
        }
        #endregion
    }
}
