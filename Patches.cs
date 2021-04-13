using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HouseBasements
{
    class Patches
    {
        /*[HarmonyPatch(typeof(LoadScene), "Start")]
        internal class UnitySceneManager
        {
            public static void Postfix(LoadScene __instance)
            {
                Implementation.Log("LoadScene Start: '{0}'", __instance.name);
                if(__instance.name == "BasementDoorExitCollider")
                {
                    GameObject obj = __instance.gameObject;
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(2.2f, 1.333f, 3.2f);
                }
            }
        }*/
        /*[HarmonyPatch(typeof(EmptyScene), "LoadScene")]
        internal class EmptyScene6
        {
            public static void Postfix(string scene)
            {
                Implementation.Log("Load "+scene);
                if(scene == "CoastalHouseE")
                {
                    GameObject obj = GameObject.Find("Root/Design/Scripting/BasementDoorExitCollider");
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(2.2f, 1.333f, 3.2f);
                }
            }
        }*/
        [HarmonyPatch(typeof(GameManager), "Awake")]
        internal class EmptyScene6
        {
            public static void Postfix()
            {
                string scene = GameManager.m_ActiveScene;
                Implementation.Log("Awake "+scene);
                if (scene == "CoastalHouseE")
                {
                    GameObject obj = GameObject.Find("Root/Design/Scripting/BasementDoorExitCollider");
                    LoadScene loadScene = obj?.GetComponent<LoadScene>();
                    if (loadScene) loadScene.m_SceneCanBeInstanced = true;
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(2.2f, 1.333f, 3.2f);
                }
                else if (scene == "CoastalHouseF")
                {
                    GameObject obj = GameObject.Find("Root/Design/Scripting/BasementDoorExitCollider");
                    LoadScene loadScene = obj?.GetComponent<LoadScene>();
                    if (loadScene) loadScene.m_SceneCanBeInstanced = true;
                    obj.SetActive(true);
                }
            }
        }
    }
}
