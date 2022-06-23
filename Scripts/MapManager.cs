﻿using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

namespace StsMap
{
    public class MapManager : MonoBehaviour
    {
        public MapConfig config;
        public MapView view;

        public Map CurrentMap { get; private set; }

        private void Start()
        {
            // TODO change this quick & dirty save
            // if (PlayerPrefs.HasKey("Map"))
            // {
            //     var mapJson = PlayerPrefs.GetString("Map");
            //     var map = JsonConvert.DeserializeObject<Map>(mapJson);
            //     // using this instead of .Contains()
            //     if (map.path.Any(p => p.Equals(map.GetBossNode().point)))
            //     {
            //         // payer has already reached the boss, generate a new map
            //         GenerateNewMap();
            //     }
            //     else
            //     {
            //         CurrentMap = map;
            //         // player has not reached the boss yet, load the current map
            //         view.ShowMap(map);
            //     }
            // }
            // else
            // {
            GenerateNewMap();
            // }
        }

        public void GenerateNewMap()
        {
            var map = MapGenerator.GetMap(config);
            CurrentMap = map;
            // Debug.Log(map.ToJson());
            view.ShowMap(map);
        }

        // TODO saving
        // public void SaveMap()
        // {
        //     if (CurrentMap == null) return;

        //     var json = JsonConvert.SerializeObject(CurrentMap);
        //     PlayerPrefs.SetString("Map", json);
        //     PlayerPrefs.Save();
        // }

        // TODO saving
        // private void OnApplicationQuit()
        // {
        //     SaveMap();
        // }
    }
}
