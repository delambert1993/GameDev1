using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersOverlap : MonoBehaviour
{
    public float amount;
    public bool colisionEnemy;
    Collider[] hitEnemies;
    public string enemyTag = "Enemy";

    private void FixedUpdate()
    {
        HitBox();
    }
    void HitBox()
    {
        hitEnemies = Physics.OverlapSphere(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), amount);

        foreach (var i in hitEnemies)
        {
            if(i.CompareTag(enemyTag))
            {
                colisionEnemy = true;
                Debug.Log(i.name);
            }       
            else
            {
                colisionEnemy = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, amount);
    }
}