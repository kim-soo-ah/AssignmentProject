
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameShooting : MonoBehaviour
{
    private ProjectileManager projectileManager;
    private PlayerController playerController;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.zero;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        projectileManager = SingletonHandler<ProjectileManager>.Instance.GetComponent<ProjectileManager>();
        playerController.OnAttackEvent += OnShoot;
        playerController.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberofProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberofProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;

        for(int i = 0; i < 5; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
        
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        projectileManager.ShootBullet(
            projectileSpawnPosition.position,
            RotateVector2(_aimDirection,angle),
            rangedAttackData
            );
    }

    private static Vector2 RotateVector2( Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
