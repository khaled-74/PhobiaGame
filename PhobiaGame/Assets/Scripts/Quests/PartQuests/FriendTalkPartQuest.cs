using System.Collections;
using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Quests.PartQuests
{
    public class FriendTalkPartQuest : Quest
    {
        [SerializeField] private TMP_Text talkText;
        [SerializeField] private float durationToDisappear = 5;
        [HideInInspector] public Order SelectedOrder;
        
        public override IEnumerator Progress()
        {
            SelectedOrder = (Order)Random.Range(0, 3);
            talkText.text = "I need, " + SelectedOrder.ToString();
            Debug.Log("Friend Is Talking");
            yield return new WaitForSeconds(durationToDisappear);
            talkText.gameObject.SetActive(false);
            Debug.Log("Friend Is Stopped Talking");
            IsFinished = true;
        }
    }
}