using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class GamingPool {
    public string name;
    public GamingPoolGameObject prefab;
    public List<GamingPoolGameObject> unusedGameObjects;
    public List<GamingPoolGameObject> usingGameObjects;
    public GamingPool() {
        unusedGameObjects = new List<GamingPoolGameObject>();
        usingGameObjects = new List<GamingPoolGameObject>();
    }
    public GamingPoolGameObject GetGameObject(Vector3 place, quaternion orient) {
        if(unusedGameObjects.Count == 0){
            usingGameObjects.Add(GamingPoolSystem.initGameObject(prefab, place, orient).GetComponent<GamingPoolGameObject>());
        }else{
            usingGameObjects.Add(unusedGameObjects.First());
            unusedGameObjects.RemoveAt(0);
        }
        var obj = usingGameObjects.Last();
        obj.transform.SetPositionAndRotation(place, orient);
        obj.gameObject.SetActive(true);
        obj.Init();
        return obj;
    }

    public void GiveBackGameObject(GamingPoolGameObject gameObject) {
        usingGameObjects.Remove(gameObject);
        unusedGameObjects.Add(gameObject);
        gameObject.gameObject.SetActive(false);
    }
}
