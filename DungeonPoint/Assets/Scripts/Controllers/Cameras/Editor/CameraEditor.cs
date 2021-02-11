using Game.Controllers;
using UnityEditor;
using UnityEngine;
namespace Editors
{
    [CustomEditor(typeof(CameraController))]
    public class CameraEditor : Editor
    {
        #region Variables
        private CameraController cam;
        #endregion
        #region Main Methods
        private void OnEnable()
        {
            cam = (CameraController)target;            
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        void OnSceneGUI()
        {
            if(!cam.target)
            {
                return;
            }
            //Guardar la referencia al target
            Transform camTarget = cam.target;
            //Dibujar la distancia del disco
            Handles.color = new Color(1f, 0f, 0f, 0.15f);
            Handles.DrawSolidDisc(cam.target.position, Vector3.up, cam.distance);
            Handles.color = new Color(1f, 1f, 0f, 0.75f);
            Handles.DrawWireDisc(cam.target.position,Vector3.up, cam.distance);

            //Editor Visual para ajustar la camara
            Handles.color = new Color(1f, 0f, 0f, 0.15f);
            cam.distance = Handles.ScaleSlider(cam.distance, camTarget.position, -camTarget.forward, Quaternion.identity, cam.distance, 1f);
            cam.distance = Mathf.Clamp(cam.distance, 5f, float.MaxValue);
            
            Handles.color = new Color(0f, 0f, 1f, 0.75f);
            cam.height = Handles.ScaleSlider(cam.height, camTarget.position, Vector3.up, Quaternion.identity, cam.height, 1f);
            cam.height = Mathf.Clamp(cam.height, 5f, float.MaxValue);
            //Fin del editor

            //Crear labels
            GUIStyle labelSylte = new GUIStyle();
            labelSylte.fontSize = 15;
            labelSylte.normal.textColor = Color.white;
            labelSylte.alignment = TextAnchor.UpperCenter;

            Handles.Label(camTarget.position + (-camTarget.forward * cam.distance), "Distance", labelSylte);

            labelSylte.alignment = TextAnchor.MiddleRight;
            Handles.Label(camTarget.position + (Vector3.up * cam.height), "Height", labelSylte);
        }
        #endregion
        #region Helper Methods
        #endregion
    }
}
