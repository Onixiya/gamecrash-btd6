using MelonLoader;
using NKHook6.Api.Events;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Unity.UI.InGameMenu;
using System;
using System.Threading;

namespace GameCrash
{
    public class GameCrash : MelonMod
    {
        Random rnd = new Random(); //rnd var for getting random numbers
        float timer = 0.0f; //timer float so we can know when to attempt a quit
        float limit = 10.0f; //how long before the next attempt at quitting will be in seconds, its a float as well bc timer is a float
        public override void OnApplicationStart() //runs only once
        {
            string msg = "your game now has a small chance of quitting, have fun"; //first string
            base.OnApplicationStart();
            EventRegistry.instance.listen(typeof(GameCrash)); //idk wtf this does but i've seen it in other mods so adding it anyway just to be safe
            MelonLogger.Log(msg); //prints the string msg to console
        }
        public override void OnUpdate() //runs every frame
        {
            base.OnUpdate();
            timer += UnityEngine.Time.deltaTime; //the heart of it, gets time since the last frame was done and adds it to timer
            if (timer > limit) //i would like it to execute exactly on limit but the chance of a frame being done exactly on it is pretty damn low
            {
                if (rnd.Next(0, 10000)==42) //gets a random number and if its equal to 42 (why not?), it runs the stuff below it
                {
                    string msg = "HAHAHAHAHAH"; //another string, shits and giggles
                    MelonLogger.Log(msg + " git fuked");//prints msg and git fuked to console
                    PopupScreen.instance.ShowPopup(0, msg, msg, null, msg, null, msg, 0);
                    /*shows a popup screen letting you know that your btd6 is about to shit itself
                    the first 0 is for setting the position of the popup which in this case, is the center
                    next 2 msg are for the title and body of what the popup should say
                    null is what action should execute when you press the left button, since this is just for shits and giggles, its been set to null
                    next msg is for what the left button should say
                    this null is the same as the other one, except its for the right button
                    same thing as the other msg, just for the right
                    this 0 is for what kind of transition the popup should use, 0 just makes it slide in when coming up and leaving the screen*/
                    Thread.Sleep(5000); //pauses the whole btd6 process for 5 seconds, Sleep() uses milliseconds
                    Environment.Exit(0); //quits the btd6 process
                }
                else //runs when the if above is false
                {
                    timer = 0.0f; //sets timer back to 0
                }
            }
        }
    }
}