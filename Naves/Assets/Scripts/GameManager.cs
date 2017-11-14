using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public EstadoJugador estado;

    private void Awake()
    {
        if(!gameManager)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this);
        }
    }
} 
