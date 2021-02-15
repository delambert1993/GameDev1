using System.Collections;
using UnityEngine;

namespace TopDownEngine.Examples
{
    [ExecuteInEditMode]
    public class FindNearestEnemyExample : MonoBehaviour
    {
        //Mascara de capa que filtrara los resultados del OverlapSphere
        //En estas capas estaran los enemigos y objetos que quieras que el personaje
        //identifique
        public LayerMask targetLayer;
        //Rango de busqueda
        public float sightRange = 8;

        //Puntero de enemigo mas cercano
        GameObject enemyPointer;

        // Use this for initialization
        void Start()
        {
            if (!enemyPointer)
                enemyPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }

        // Update is called once per frame
        void Update()
        {
            //Chequeamos si existe algun enemigo en el rango del personaje
            if (GetNearestEnemy())
            {
                //Si lo hay, entonces lo señalamos
                enemyPointer.transform.position = GetNearestEnemy().position + Vector3.up * 3;
            }
        }

        Transform GetNearestEnemy()
        {
            //Inicializo el metodo OverlapSphere con la posicion del personaje, el rango de
            //busqueda y la mascara de capa
            //Solo me va a devolver aquellos objetos que se encuentren en esas capas
            Collider[] targets = Physics.OverlapSphere(transform.position, sightRange, targetLayer);

            //Distancia minima acutal
            float minDst = Mathf.Pow(sightRange, 2);
            //Enemigo mas cercano actual
            Transform nearestTarget = null;

            //Me muevo por todo el arreglo. Foreach en este caso es la mejor opcion
            foreach (Collider t in targets)
            {
                //Trabajamos con la magnitud cuadrada. Asi no ahorramos las raices cuadradas
                //que son caras de hallar y como es un metodo que se usa en cada frame
                //no es aconsejable usarlas
                float sqrDst = (transform.position - t.transform.position).sqrMagnitude;
                //Si la magnitud cuadrada es menor a la distancia minima actual
                if (sqrDst < minDst)
                {
                    //La distancia minima actual es la nueva magnitud cuadrada
                    minDst = sqrDst;
                    //El enemigo mas cercano actual es el nuevo objecto
                    nearestTarget = t.transform;
                }
            }

            //Retornamos el enemigo mas cercano
            return nearestTarget;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}