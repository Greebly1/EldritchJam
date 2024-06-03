using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UltEvents;

public class WizardProjectile : MonoBehaviour
{
    private float damage;
    private float radius;
    private Weapon source;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private UltEvent OnDestroy;

    private bool isActive = true;

    public void Init(float _damage, float _radius, Weapon _source)
    {
        damage = _damage;
        source = _source;
        radius = _radius;
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
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            IDamageAble overlappedEnemy = collider.GetComponent<IDamageAble>();
            if (overlappedEnemy != null )
            {
                overlappedEnemy.Damage(new DamageData(Mathf.RoundToInt(damage), source.gameObject, Team.Player));
            }
        }
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
