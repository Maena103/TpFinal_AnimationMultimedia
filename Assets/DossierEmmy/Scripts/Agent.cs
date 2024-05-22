using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] private GameObject _joueur;
    [SerializeField] private NavMeshAgent _agent;
  private LevelManager _levelManager;

    // Position du joueur que l'agent doit suivre
    private Vector3 _positionJoueur;
    
    // Pour faire le changement de scene 
    //[SerializeField] private GestionnaireScenes  _gestionScenes;

    // Pour les scriptable objects 
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private InfosNiveau _infosDuNiveau;

      void Start()
    {
        _levelManager = LevelManager.Instance;
    }
    void Update()
    {
        BougerAgent();
    }

    void BougerAgent(){
        // Dit à l'agent d'aller à la position du joueur
        _positionJoueur = _joueur.transform.position;
        _agent.SetDestination(_positionJoueur);
    }

     private void OnTriggerEnter(Collider other){
 
        // Debug pour savoir la cause de la mort 
      

        if(other.gameObject.tag == "Player"){
             //Pour indiquer que le joueur est mort à cause de l'agent sois le bateau sur l'interface final de défaite
            _infosJoueurs._causeMort = ("Bateau");
            _levelManager.LoadAsyncScene(LevelManager.Scene.SceneMort);
             //Pour effectuer le changement de scene
         //   _gestionScenes.SceneSuivante();
             // Indique s'il y a une défaite ou une victoire dans se cas, c'est une défaite et vient changer la valeur de la booléen dans infosNiveau 
             //ce qui permet de changer l'interface final dépendement si il y a une victoire ou une défaite
          //  _infosDuNiveau._victoirePartie = false;
            //_infosDuNiveau._defaitePartie = true;
           
        }
   
  }
}
