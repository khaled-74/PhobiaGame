using System.Collections;
using AI;
using Quests;
using UnityEngine;

namespace Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Quest[] tasks;
    
        private int _activeTaskIndex = 0;
    
        void Start()
        {
            _activeTaskIndex = 0;
            StartCoroutine(Loop());
        }

        private IEnumerator Loop()
        {
            while (_activeTaskIndex < tasks.Length)
            {
                StartCoroutine(tasks[_activeTaskIndex].Progress());
                while (!tasks[_activeTaskIndex].IsFinished)
                {
                    yield return null;
                }

                _activeTaskIndex += 1;
            }
        }
    }
}
