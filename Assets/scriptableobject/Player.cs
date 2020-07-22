using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Datos", menuName = "Scriptables/Datos Personaje")]
public class Player : ScriptableObject
{
    //Movimientos
    public float VelocidadJugador = 40f;
    public float FuerzaSalto = 3f;
    public float RatioDisparo = 0.5f;
    public float WallJumpFuerza = 2f;

    //Salud y estados
    public int Salud = 1;
    public int Vidas = 3;
    public float StunDanno = 0.1f;

    //Bullets
    public float VelocidadBala = 7f;
    public float TiempoExistencia = 0.5f;
    public int Danno = 1;


}
