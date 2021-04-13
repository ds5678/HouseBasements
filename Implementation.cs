using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace HouseBasements
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }
        internal static void Log(string message, params object[] parameters) => MelonLogger.Log(message, parameters);
    }
}
