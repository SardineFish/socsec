using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MapLoader : MonoBehaviour {
    public List<string> AvailableScenes;

    Scene mapLoaded;
    public Scene MapLoaded
    {
        get { return mapLoaded; }
        set
        {
            if (Application.isEditor)
                mapLoaded = value;
            else
            {
                SceneManager.UnloadSceneAsync(mapLoaded);
                SceneManager.LoadSceneAsync(value.path);
            }

        }
    }
    
    [SerializeField]
    string mapPath;
    public string MapPath
    {
        get { return mapPath; }
        set
        {
            mapPath = value;
            
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMap(string path)
    {
        SceneManager.UnloadSceneAsync(MapLoaded);
        SceneManager.LoadScene(path);
        mapLoaded = SceneManager.GetSceneByPath(path);
    }
}
