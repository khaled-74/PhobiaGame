using System.Collections;
using Quests.PartQuests;
using Quests;
using UnityEngine;

namespace Quests
{
    public class FirstSceneQuest : Quest
    {
        [SerializeField] private FriendTalkPartQuest friendTalkPartQuest;
        [SerializeField] private OrderPartQuest orderPartQuest;
        [SerializeField] private DropCoffeePartQuest dropCoffeePartQuest;
        
        public override IEnumerator Progress()
        {
            OnStartQuest?.Invoke();
            
            // Start Conversation With The NPC and wait until the NPC finish talk
            StartCoroutine(friendTalkPartQuest.Progress());
            while (!friendTalkPartQuest.IsFinished)
                yield return null;
            Debug.Log("Friend Order: " + friendTalkPartQuest.SelectedOrder);
            Debug.Log("Friend Talk Finished");
            
            // Player go to the cashier to get the order
            // If the player selected the wrong one lose points 
            orderPartQuest.SelectedOrder = friendTalkPartQuest.SelectedOrder;
            StartCoroutine(orderPartQuest.Progress());
            while (!orderPartQuest.IsFinished)
                yield return null;
            Debug.Log("Order Finished");
            
            // Else Continue until collide to spell the cub
            StartCoroutine(dropCoffeePartQuest.Progress());
            while (!dropCoffeePartQuest.IsFinished)
                yield return null;
            Debug.Log("Drop Coffee Finished");
            
            yield return null;
            
            OnEndQuest?.Invoke();
        }
    }
}