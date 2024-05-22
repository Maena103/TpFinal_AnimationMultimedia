using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsDefaite : MonoBehaviour
{
    
    
    // Référence aux scriptables objects
    [SerializeField] private InfosJoueurs _infosJoueurs;
    [SerializeField] private InfosNiveau _infosDuNiveau;
    
    // Référence aux textes et au canvas dans l'interface de défaite
    //[SerializeField] private TMP_Text _texteNomJoueur;
    [SerializeField] private TMP_Text _texteCauseMort;
    [SerializeField] private Canvas _canvasDefaite;
    //[SerializeField] private TMP_Text _texteNbPoints;
   // [SerializeField] private TMP_Text _temps;
  //  [SerializeField] private TMP_Text _texteNomEnvironnement;
    
    
    void Start()
    {
        //Si dans infosNiveau la variable défaitepartie est à true on effectue le code
         if(_infosDuNiveau._defaitePartie==true){
            //On setActive le canvas défaite
            _canvasDefaite.gameObject.SetActive(true);
        }
        //On affiche les informations 
      //  _temps.text = _infosDuNiveau._tempsDeJeu.ToString();
       // _texteNbPoints.text = _infosJoueurs._nbPoints.ToString();
       // _texteNomJoueur.text = _infosJoueurs._prenomJoueurs;
       // _texteNomEnvironnement.text = _infosDuNiveau.leNomDuNiveau;
       // _texteCauseMort.text = _infosJoueurs._causeMort;
    }
}