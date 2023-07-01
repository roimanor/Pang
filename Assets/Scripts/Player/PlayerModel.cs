using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private float playerVelocity = 5f;
    public float PlayerVelocity => playerVelocity;

    [SerializeField] private GameObject arrowPrefab;
    public GameObject ArrowPrefab => arrowPrefab;

    [SerializeField] private float shootCD;
    public float ShootCD => shootCD;


}
