using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CultistProjectile : MonoBehaviour
{
    private int damage;
    private Weapon source;

    [SerializeField]
    private UnityEvent OnDestroy;

    public void Init(int _damage, Weapon _source)
    {
        damage = _damage;
        source = _source;
    }

    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageAble enemy = collision.GetComponent<IDamageAble>();
        if(enemy != null )
        {
            CollideWithEnemy(enemy);
        }
        else
        {
            CollideWithEnvironment();
        }
    }

    private void CollideWithEnemy(IDamageAble enemy)
    {
        enemy.Damage(new DamageData(damage, source.gameObject, Team.Player));
        DestroyProjectile();
    }

    private void CollideWithEnvironment()
    {
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        OnDestroy.Invoke();
        Destroy(gameObject);
    }
}
