using Game.Controllers;
using UnityEditor;
using UnityEngine;
namespace Editors
{
    public class CameraMenu : MonoBehaviour
    {
        [MenuItem("Systems/Cameras/Top Down Camera")]
        public static void CreateTopDownCamera()
        {
            GameObject[] selectedGO = Selection.gameObjects;

            if(selectedGO.Length > 0 && selectedGO[0].GetComponent<Camera>())
            {
                if(selectedGO.Length < 2)
                {
                    AttacheTopDownScript(selectedGO[0], null);
                }
                else if(selectedGO.Length == 2)          
                {
                    AttacheTopDownScript(selectedGO[0].gameObject, selectedGO[1]);
                }
                else if(selectedGO.Length == 3)
                {
                    EditorUtility.DisplayDialog("Camera Tools", "You can only select two GameObjects in the scene for this to work and the first selections need to be a camera", "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Camera Tools", "You need to select a GameObject in the Scene that has a camera assign it!", "Ok");
            }
        }
        static void AttacheTopDownScript(GameObject camera, GameObject target)
        {
            //Assigna el script a la camara
            CameraController cam = null;
            if (camera)
            {
                cam = camera.AddComponent<CameraController>();            
                //Tenemos un target? tenemos script?
                if (cam && target)
                {
                    cam.target = target.transform;
                }
                Selection.activeObject = camera;
            }
        }
    }
}
