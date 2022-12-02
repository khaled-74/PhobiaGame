using System.Collections;
using Quests;
using UnityEngine;

namespace Quests.PartQuests
{
    public class FriendTalkPartQuest : Quest
    {
        public Order SelectedOrder;
        
        public override IEnumerator Progress()
        {
            SelectedOrder = (Order)Random.Range(0, 3);
            Debug.Log("Friend Is Talking");
            yield return new WaitForSeconds(2.5f);
            Debug.Log("Friend Is Stopped Talking");
            IsFinished = true;
        }
    }
}