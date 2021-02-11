namespace Game.Controllers
{    
    using UnityEngine;
    public class Cam : MonoBehaviour
    {
        
        private Camera _camObj;
        public Camera camObj { get => _camObj; set => _camObj = value; }

        //Inicializamos y adjuntamos el obj Camera de unity
        public Cam(Camera CamObj)
        {
            camObj = CamObj;
        }
        [SerializeField]
        private Transform _target;
        public Transform target { get => _target; private set => _target = value; }
        [SerializeField]
        private float _offset;
        internal object cam;

        // Update is called once per frame
        void Update()
        {
            if (_target != null)
            {
                LookTarget();
            }
            else
            {
                Debug.Log("No target added to camera");
            }
    }
        public void LookTarget()
        {
            this.transform.LookAt(_target);
        }

        public void SetTarget(Transform Target)
        {
            this.gameObject.transform.position = Target.position;
            this.target = Target;
        }

    
    }
}

