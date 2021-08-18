using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Information", menuName = "MonsterInformation")]
public class MonsterInfor : ScriptableObject
{
    public int star;
    public int damge;
    public int health;
    public float speed;
}
