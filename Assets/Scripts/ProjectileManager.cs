using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : SingletonHandler<ProjectileManager>
{
    [SerializeField] private ParticleSystem _impactParticleSystem;

    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializedAttack(direction, attackData, this);

        obj.SetActive(true);
    }


}
