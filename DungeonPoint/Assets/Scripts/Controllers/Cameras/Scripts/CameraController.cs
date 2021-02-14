namespace Game.Controllers
{
    using UnityEngine;
    public class CameraController : MonoBehaviour
    {
        

        #region Variables
        private Transform _target;
        public Transform target { get => _target; set => _target = value; }
        [SerializeField]
        private float _height;
        public float height { get => _height; set => _height = value; }
        [SerializeField]
        private float _distance;
        public float distance { get => _distance; set => _distance = value; }
        [SerializeField]
        private float _angle;
        public float angle { get => _angle; set => _angle = value; }
        [SerializeField]
        private Camera _cam;
        public Camera cam { get => _cam; set => _cam = value; }
        private GameManager _gameManager;
        public GameManager gameManager { get => _gameManager; set => _gameManager = value; }
        public static Cam current;

        private Vector3 _refVel;
        private float _smoothSpeed;
        #endregion
        public CameraController()
        {
            this.distance = 20f;
            this.height = 10f;
            this.angle = 45f;
            this._smoothSpeed = 0.5f;
        }
        #region Main Methods
        void Start()
        {
            InitialiceClass();
            HandleCamera();            
        }
        void Update()
        {
            HandleCamera();
        }
        #endregion
        
        #region HelperRegion
        void InitialiceClass()
        {
            this.cam = this.GetComponent<Camera>();
        }
        protected virtual void HandleCamera()
        {
            //Si no hay target, sale de la funcion
            if(!target)
            {
                return;
            }
            //World Position Vector sobre el target
            Vector3 worldPosition = (Vector3.forward * distance) + (Vector3.up * height);
            Debug.DrawLine(target.position, worldPosition, Color.red);

            //Vector rotado
            Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
            Debug.DrawLine(target.position, rotatedVector, Color.green);

            //Mover la posicion de la camara
            Vector3 flatTargetPosition = target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref _refVel, _smoothSpeed);
            transform.LookAt(flatTargetPosition);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.256f);
            if(target)
            {
                Gizmos.DrawLine(transform.position, target.position);
                Gizmos.DrawSphere(target.position, 1.5f);
            }
            Gizmos.DrawSphere(transform.position, 1.5f);
        }
        public void SetTarget(Transform Target)
        {
            this.target = Target;
        }

        #endregion
    }
}
