using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UltEvents;

public class CultistProjectile : MonoBehaviour
{
    private float damage;
    private Weapon source;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private UltEvent OnDestroy;

    [SerializeField]
    private SpriteRenderer boneSprite;
    [SerializeField]
    private float rotateSpeed = 10;

    public void Init(float _damage, Weapon _source)
    {
        damage = _damage;
        source = _source;
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        boneSprite.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
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
        OnDestroy.Invoke();
    }
}
