using MelonLoader;
using NKHook6.Api.Events;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Unity.UI.InGameMenu;
using System;
using System.Threading;

namespace test
{
    public class test : MelonMod
    {
        Random rnd = new Random();
        float timer = 0.0f;
        float limit = 10.0f;
        public override void OnApplicationStart()
        {
            string msg = "test";
            base.OnApplicationStart();
            EventRegistry.instance.listen(typeof(test));
            MelonLogger.Log(msg);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            timer += UnityEngine.Time.deltaTime;
            if (timer > limit)
            {
                if (rnd.Next(0, 100)==52)
                {
                    string msg = "HAHAHAHAHAH";
                    MelonLogger.Log(msg + " git fuked");
                    PopupScreen.instance.ShowPopup(0, msg, msg, null, msg, null, msg, 0);
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    timer = 0.0f;
                }
            }
        }
    }
}