using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuQuitter : MonoBehaviour
{
   [SerializeField] Button _quitterGame;

    private LevelManager _levelManager;
    // Start is called before the first frame update
    void Start()
    {
        _levelManager = LevelManager.Instance;
      
        _quitterGame.onClick.AddListener(QuitterGame);
    }

    private void QuitterGame()
    {
      _levelManager.QuiteGame();
    }
}
