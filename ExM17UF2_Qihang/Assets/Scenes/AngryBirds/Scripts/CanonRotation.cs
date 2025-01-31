using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour
{
    public Vector3 _maxRotation;
    public Vector3 _minRotation;
    private float offset = -51.6f;
    public GameObject ShootPoint;
    public GameObject Bullet;
    public float ProjectileSpeed = 0;
    public float MaxSpeed;
    public float MinSpeed;
    public GameObject PotencyBar;
    private float initialScaleX;

    private void Awake()
    {
        initialScaleX = PotencyBar.transform.localScale.x;
    }
    void Update()
    {
        //PISTA: mireu TOTES les variables i feu-les servir

        Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition); //guardem posici� del ratol� a la c�mera
        Vector2 direction =  mousePos - (Vector2) this.transform.position; //vector entre el click i la bala
        var angle = (Mathf.Atan2(direction.y, direction.x) * 180f / Mathf.PI + offset);

        if (angle > _maxRotation.z || angle < _minRotation.z) return;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        if (Input.GetMouseButton(0))
        {
            ProjectileSpeed += 4 * Time.deltaTime; //cada segon s'ha de fer 4 unitats m�s gran
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            var projectile = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity); //On s'instancia?
            
            projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * ProjectileSpeed; //quina velocitat ha de tenir la bala? 
            
            //float X = ProjectileSpeed * Mathf.Cos(angle);
            //float Y = ProjectileSpeed * Mathf.Sin(angle);
            //projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(X,Y);

            ProjectileSpeed = 0f; //reset despr�s del tret
        }
        CalculateBarScale();

    }
    public void CalculateBarScale()
    {
        PotencyBar.transform.localScale = new Vector3(Mathf.Lerp(0, initialScaleX, ProjectileSpeed / MaxSpeed),
                                                    PotencyBar.transform.localScale.y,
                                                    PotencyBar.transform.localScale.z);
    }
}
