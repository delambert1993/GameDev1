using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersOverlap : MonoBehaviour
{
    public float amount;
    public bool colisionEnemy = false;
    Collider2D[] hitEnemiesZY;
    Collider2D[] hitEnemiesZX;
    void A()
    {
        Physics2D.OverlapCircleAll(new Vector2(this.transform.position.z, this.transform.position.y), amount);
        
    }
    private void FixedUpdate()
    {
        HitBoxZY();
        HitBoxZX();
    }
    void HitBoxZY()
    {
        hitEnemiesZY = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.z, this.transform.position.y), amount);

        foreach (var i in hitEnemiesZY)
        {
            if(i.gameObject.tag == ("Enemy"))
            {
                foreach (var enemy in HIT)
                {

                }
                colisionEnemy = true;
                f (colisionEnemy)
                {
                    Debug.Log("Enemy colision");
                }       
            }
            else
            {
                colisionEnemy = false;
                Debug.Log("____________________");
            }
        }
    }
        
    void HitBoxZX()
    {
         hitEnemiesZX = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.z, this.transform.position.y), amount);

        foreach (var i in hitEnemiesZX)
        {
            if (i.gameObject.tag == ("Enemy"))
            {
                colisionEnemy = true;
                while (colisionEnemy)
                {
                    Debug.Log("Enemy colision");
                }
            }
            else
            {
                colisionEnemy = false;
                Debug.Log("____________________");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, amount);
    }
}