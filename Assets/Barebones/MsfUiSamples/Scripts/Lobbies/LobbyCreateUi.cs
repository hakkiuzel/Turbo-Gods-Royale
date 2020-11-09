using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Barebones.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace Barebones.MasterServer
{
    /// <summary>
    /// Represents a simple window, which demonstrates 
    /// how lobbies can be created
    /// </summary>
    public class LobbyCreateUi : MonoBehaviour
    {
        public Dropdown TypeDropdown;
        public Dropdown MapDropdown;
        public InputField Name;
        public LobbyUi LobbyUi;

      
        public List<GameObject> Children;
        public List<GameObject> GS_List;

        // timeouts and waits
        private float SearchGame = 10f;
        private float CreateGame = 5f;

        public Transform parent;
        public GameObject Item1;
        public GamesListUi ui;
        public bool wasExecuted = false;
        public bool wasRequested = false;
        public bool allow = false;
        public int secs = 0;

        /// <summary>
        /// List of available lobby factories
        /// </summary>
        public List<CustomPair> LobbyFactories = new List<CustomPair>();

        /// <summary>
        /// A list of maps
        /// </summary>
        public List<MapEntry> Maps = new List<MapEntry>();

        protected virtual void Awake()
        {
            LobbyUi = LobbyUi ?? FindObjectOfType<LobbyUi>();

            if (LobbyUi == null)
            {
                Logs.Error("Lobby window was not set. ");
            }
        }

        protected virtual void Start()
        {
            TypeDropdown.ClearOptions();
            TypeDropdown.AddOptions(LobbyFactories.Select(t => t.Value).ToList());

            MapDropdown.ClearOptions();
            MapDropdown.AddOptions(Maps.Select(t => t.MapTitle).ToList());



            InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s

        }


        void OutputTime()
        {
            secs++;
            ui.OnRefreshClick();
            if(secs == 10)
            {
                allow = true;
            }


        }



        public void searchingError()
        {
            allow = false;
            secs = 0;
            GS_List.Clear();
            InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s
           


        }

        void Update()
        {

            if (allow)
            {
                getList();
                GS_List = Children.Distinct().ToList();




                if (GS_List.Count > 0)
                {
                     
                    Item1 = GS_List[GS_List.Count - 1];
                    Item1.GetComponent<GamesListUiItem>().SetIsSelected(true);
                    Item1.GetComponent<GamesListUiItem>().SelectedBgColor = Color.red;
                    if (!wasRequested)
                    {
                        ui.OnJoinGameClick();
                        wasRequested = true;
                    }



                }

                else
                {
                    if (!wasExecuted)
                    {
                        
                        OnCreateClick();
                        wasExecuted = true;
                    }

                }


            }

        }

        public void resetBoold()
        {
            wasRequested = false;
        }






        public void getList()
        {

            foreach (Transform child in parent.transform)
            {
                if (child.tag == "ServerItem")
                {
                    Children.Add(child.gameObject);
                    if (Children[0].gameObject.activeInHierarchy == false)
                    {
                        Children.RemoveAt(0);
                    }

                }
            }


        }



        /// <summary>
        /// Invoked, when user clicks a "Create" button
        /// </summary>
        public virtual void OnCreateClick()
        {
            var properties = new Dictionary<string, string>()
            {
                {MsfDictKeys.LobbyName, Name.text },
                {MsfDictKeys.SceneName, GetSelectedMap() },
                {MsfDictKeys.MapName, MapDropdown.captionText.text}

            };

            var loadingPromise = Msf.Events.FireWithPromise(Msf.EventNames.ShowLoading, "Sending request");

            var factory = GetSelectedFactory();

            Msf.Client.Lobbies.CreateAndJoin(factory, properties, (lobby, error) =>
            {
                loadingPromise.Finish();

                if (lobby == null)
                {
                    Msf.Events.Fire(Msf.EventNames.ShowDialogBox, DialogBoxData.CreateError(error));
                    Logs.Error(error + " (Factory: " + factory + ")");
                    return;
                }

                // Hide this window
                gameObject.SetActive(false);

                if (LobbyUi != null)
                {
                    // Show the UI
                    LobbyUi.gameObject.SetActive(true);

                    // Set the lobby Ui as current listener
                    lobby.SetListener(LobbyUi);
                }
                else
                {
                    Logs.Error("Please set LobbyUi property in the inspector");
                }
            });
        }

        IEnumerator DoCheck()
        {
            for (; ; )
            {
                Children.Clear();
                getList();
                yield return new WaitForSeconds(.1f);
            }
        }

        /// <summary>
        /// Translates factory selection into the
        /// actual factory string representation
        /// </summary>
        public string GetSelectedFactory()
        {
            var text = TypeDropdown.captionText.text;
            return LobbyFactories.FirstOrDefault(m => m.Value == text).Key;
        }

        /// <summary>
        /// Translates map selection into the
        /// scene name
        /// </summary>
        public string GetSelectedMap()
        {
            var text = MapDropdown.captionText.text;
            return Maps.FirstOrDefault(m => m.MapTitle == text).SceneName;
        }

        [Serializable]
        public class CustomPair
        {
            public string Key;
            public string Value;

            public CustomPair(string key, string value)
            {
                Key = key;
                Value = value;
            }

        }

        [Serializable]
        public class MapEntry
        {
            public string SceneName;
            public string MapTitle;

            public MapEntry(string sceneName, string mapTitle)
            {
                SceneName = sceneName;
                MapTitle = mapTitle;
            }

        }
    }
}