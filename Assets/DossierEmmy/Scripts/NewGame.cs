using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private InfosNiveau _infosDuNiveau;

    // Start is called before the first frame update
    void Start()
    {
        _infosDuNiveau.init();
    }

   
}
