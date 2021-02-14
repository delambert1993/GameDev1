using Game;
using Game.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI_FX
{
    public class LookToCamara : MonoBehaviour
    {
        TextMeshProUGUI txt;
        private void Update()
        {
            this.GetComponent<TextMeshProUGUI>().rectTransform.LookAt(FindObjectOfType<CameraController>().cam.transform.position);
        }
    }
}
