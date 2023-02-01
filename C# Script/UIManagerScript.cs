using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{

    public GameObject core;
    public GameObject placeCoreButton;

    private RayCastManager raycastManager;


    public static UIManagerScript instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        core.SetActive(false);

        raycastManager = FindObjectOfType<RayCastManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceCore()
    {
        core.SetActive(true);

        

        core.transform.position = raycastManager.transform.position;

        raycastManager.gameObject.SetActive(false);

        placeCoreButton.SetActive(false);

        EnemySpawner.instance.canSpawnEnemy = true;
    }
}
