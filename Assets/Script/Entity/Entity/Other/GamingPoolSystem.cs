using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GamingPoolSystem : MonoBehaviour {
    public List<GamingPool> gamingPools;
    public static GameObject initGameObject(GameObject prefab, Vector3 place, quaternion orient) {
        return Instantiate(prefab, place, orient);
    }

    public void RegisterGamingPool(string name, GameObject prefab) {
        this.gamingPools.Add(new GamingPool(){
            name = name,
            prefab = prefab
        });
    }
    public GameObject GetGameObject(string name, Vector3 place, quaternion orient) {
        return this.gamingPools.FirstOrDefault(x=>x.name == name)?.GetGameObject(place, orient) ?? new GameObject();
    }

    public GameObject GetGameObject(int index, Vector3 place, quaternion orient) {
        return this.gamingPools[index].GetGameObject(place, orient);
    }

    public void GiveBackGameObject(string name, GameObject gameObject) {
        this.gamingPools.FirstOrDefault(x=>x.name == name).GiveBackGameObject(gameObject);
    }

    public void GiveBackGameObject(int index, GameObject gameObject) {
        this.gamingPools[index].GiveBackGameObject(gameObject);
    }
}
