namespace Game.Controllers
{
    using Game.Entitys.Player;
    using UnityEngine;
    public class InputController : MonoBehaviour
    {
        private Animator anim;

        public InputController(Animator Anim)
        {
            anim = Anim;
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button left pressed...");
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Mouse button right pressed...");
            }
        }
    }

}
