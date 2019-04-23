using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        ps = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
    }
}
