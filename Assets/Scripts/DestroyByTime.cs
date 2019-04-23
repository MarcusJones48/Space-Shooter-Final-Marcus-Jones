using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float lifetime;

    void Start ()
    {
        Destroy (gameObject, lifetime); 
    }
}
