using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class GamingPool {
    public string name;
    public GameObject prefab;
    public List<GameObject> unusedGameObjects;
    public List<GameObject> usingGameObjects;
    public GamingPool() {
        unusedGameObjects = new List<GameObject>();
        usingGameObjects = new List<GameObject>();
    }
    public GameObject GetGameObject(Vector3 place, quaternion orient) {
        if(unusedGameObjects.Count == 0){
            usingGameObjects.Add(GamingPoolSystem.initGameObject(prefab, place, orient));
        }else{
            unusedGameObjects.First().transform.SetPositionAndRotation(place, orient);
            usingGameObjects.Add(unusedGameObjects.First());
            unusedGameObjects.RemoveAt(0);
        }
            usingGameObjects.Last().SetActive(true);
        return usingGameObjects.Last();
    }

    public void GiveBackGameObject(GameObject gameObject) {
        usingGameObjects.Remove(gameObject);
        unusedGameObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}
