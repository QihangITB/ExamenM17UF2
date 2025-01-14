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

        /*var mousePos = //guardem posició del ratolí a la càmera
        var direction = //vector entre el click i la bala
        var angle = (Mathf.Atan2(dist.y, dist.x) * 180f / Mathf.PI + offset);
        transform.rotation = Quaternion.Euler( //aplicar rotació de l'angle al canó  */

        if (Input.GetMouseButton(0))
        {
            //ProjectileSpeed += //cada segon s'ha de fer 4 unitats més gran
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            //var projectile = Instantiate(Bullet, //On s'instancia?
            //projectile.GetComponent<Rigidbody2D>().velocity = //quina velocitat ha de tenir la bala? 
            ProjectileSpeed = 0f; //reset després del tret
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
