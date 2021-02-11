using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets.Scripts.NewStatistics
{
    public enum tipoBarra
    {
        Vida,
    }
    public class statisticsBase
    {
        public tipoBarra tbarra;
        public BadImageFormatException barra;
        public TextMeshProUGUI valText;
        private float valMax;
        private float valActual;

        void Update()
        {
            if(valActual >= valMax)
            {
                valActual = valMax;
            }
            if(valActual <= 0)
            {
                valActual = 0;
            }

        }
    }
}
