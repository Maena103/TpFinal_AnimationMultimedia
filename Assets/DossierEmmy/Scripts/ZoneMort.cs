using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMort : MonoBehaviour
{
    private LevelManager _levelManager;
    [SerializeField] private AudioSource sonTeleportation;


    // Start is called before the first frame update
    void Start()
    {
        _levelManager = LevelManager.Instance;
    }


 private void OnTriggerEnter(Collider other)
 {
    sonTeleportation.Play();
   _levelManager.LoadAsyncScene(LevelManager.Scene.SceneMort);
 }
}
