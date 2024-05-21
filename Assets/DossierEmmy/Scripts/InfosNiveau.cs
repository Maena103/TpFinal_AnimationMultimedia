using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pour créer le scriptable object niveau
[CreateAssetMenu(fileName="InfosNiveau", menuName ="SO/InfosNouveauNiveau")]
public class InfosNiveau : ScriptableObject
{
    //Variable du scriptable object niveau
    [SerializeField] public float _tempsDeJeu;
    [SerializeField] public float _tempsEcoule;
    [SerializeField] public bool firstTime;
   
    public void init()
    {   Debug.Log("allo: "+firstTime);
       // if(firstTime == false)
        //{
        _tempsEcoule = _tempsDeJeu;
        firstTime = true;
     
        //}
        
    }






    //Variable qui dit si on gagne la partie
   // public bool _defaitePartie;
    //public bool _victoirePartie;


}
