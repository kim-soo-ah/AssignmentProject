using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : SingletonHandler<GameManager>
{
    public Transform Player {  get; private set; }
    [SerializeField] private string playerTag = "Player";

    

    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}
