using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShooting : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.zero;

    public GameObject testPrefab;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        playerController.OnAttackEvent += OnShoot;
        playerController.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.Euler(new Vector3(0, 0, -90)));
    }
}
