using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UltEvents;

public class WormProjectile : MonoBehaviour
{
    private float damage;
    private Weapon source;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private UltEvent OnDestroy;

    private bool isActive = true;

    public void Init(float _damage, Weapon _source, float distanceBeforeDeath)
    {
        damage = _damage;
        source = _source;
        Destroy(gameObject, distanceBeforeDeath / speed);
    }

    private void Update()
    {
        if (isActive)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
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
        enemy.Damage(new DamageData(Mathf.RoundToInt(damage), source.gameObject, Team.Player));
        DestroyProjectile();
    }

    private void CollideWithEnvironment()
    {
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        isActive = false;
        OnDestroy.Invoke();
    }
}
