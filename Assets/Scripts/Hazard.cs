using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    protected Collider2D myCollider;
    protected object myRigidbody;

    [SerializeField]
    protected float resistance = 1F;

    protected float spinTime = 1F;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null && collision.gameObject.GetComponent<APBullet>() == null)
        {

            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        } else if(collision.gameObject.GetComponent<Shelter>() != null)
        {
            resistance -= 1;
            collision.gameObject.GetComponent<Shelter>().Damage(1);
            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
    }

    protected virtual void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}