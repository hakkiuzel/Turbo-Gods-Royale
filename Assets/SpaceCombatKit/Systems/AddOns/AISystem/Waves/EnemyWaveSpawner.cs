using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VSX.Pooling;
/*
namespace VSX.UniversalVehicleCombat
{
    [System.Serializable]
    public class Wave
    {
        public int numMembers;
    }

    public class EnemyWaveSpawner : MonoBehaviour
    {
        public List<Wave> waves = new List<Wave>();

        public float waitBetweenWaves = 10f;

        protected float waitStartTime;

        protected int currentWaveIndex = -1;

        public TextMeshProUGUI waveText;

        public GameAgent pilotPrefab;
        protected List<GameAgent> pilots = new List<GameAgent>();

        public GameObject shipPrefab;

        protected bool waitingForWave;

        [SerializeField]
        protected AudioSource successAudio;

        [SerializeField]
        protected TextMeshProUGUI successText;


        private void Awake()
        {
            int maxPilots = 0;
            for (int i = 0; i < waves.Count; ++i)
            {
                if (waves[i].numMembers > maxPilots)
                {
                    maxPilots = waves[i].numMembers;
                }
            }

            for (int i = 0; i < maxPilots; ++i)
            {
                GameAgent pilot = Instantiate(pilotPrefab, Vector3.zero, Quaternion.identity);
                pilots.Add(pilot);
            }

            Color c = successText.color;
            c.a = 0;
            successText.color = c;

            StartNextWave();
        }

        protected void StartNextWave()
        {
            waitStartTime = Time.time;
            waveText.gameObject.SetActive(true);
            waitingForWave = true;
        }

        protected void UpdateWaveText()
        {
            float timeSinceStart = Time.time - waitStartTime;
            int minutes = (int)((waitBetweenWaves - timeSinceStart) / 60);
            int seconds = (int)((waitBetweenWaves - timeSinceStart) - (minutes * 60));

            string minutesString = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            string secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

            waveText.text = "NEXT WAVE IN " + minutesString + ":" + secondsString;
        }

        protected void SpawnWave()
        {

            Vector3 wavePos = Quaternion.Euler(0f, Random.Range(0, 360), 0f) * Vector3.right * 1000;
            Quaternion rot = Quaternion.LookRotation(Vector3.zero - wavePos);
            Vector3 waveRight = Quaternion.Euler(0f, 90f, 0f) * (Vector3.zero - wavePos).normalized;

            currentWaveIndex += 1;

            for (int i = 0; i < waves[currentWaveIndex].numMembers; ++i)
            {
                pilots[i].Revive();

                Vector3 pos = wavePos + (i * waveRight * 50);

                GameObject ship = PoolManager.Instance.Get(shipPrefab, pos, rot);

                Vehicle vehicle = ship.GetComponent<Vehicle>();
                vehicle.Restore();

                pilots[i].EnterVehicle(vehicle);
            }

            waitingForWave = false;
            waveText.gameObject.SetActive(false);
        }


        IEnumerator TextFadeCoroutine()
        {

            yield return new WaitForSeconds(1.5f);

            float showTime = 2;
            float fadeTime = 2;

            float startTime = Time.time;

            Color c = successText.color;
            c.a = 1;
            successText.color = c;

            yield return new WaitForSeconds(showTime);

            while (Time.time - startTime < fadeTime)
            {
                c.a = 1 - (Time.time - startTime) / fadeTime;
                successText.color = c;
                yield return null;
            }

            c = successText.color;
            c.a = 0;
            successText.color = c;
        }


        private void Update()
        {

            if (waves.Count == 0 || currentWaveIndex >= waves.Count) return;

            if (waitingForWave)
            {
                UpdateWaveText();

                if (Time.time - waitStartTime >= 10)
                {
                    SpawnWave();
                }
            }
            else
            {
                bool allDead = true;
                for(int i = 0; i < waves[currentWaveIndex].numMembers; ++i)
                {
                    if (!pilots[i].IsDead)
                    {
                        allDead = false;
                    }
                }
                if (allDead)
                {
                    successAudio.PlayDelayed(1);
                    StartCoroutine(TextFadeCoroutine());
                    StartNextWave();
                }
            }
        }
    }
}*/