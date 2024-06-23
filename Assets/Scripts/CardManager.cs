using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Deck_Manage {
    public class CardManager : MonoBehaviour
    {
        public static CardManager Inst {get; private set;}
        void Awake() => Inst = this;

        [SerializeField] WordSO wordSO;
        [SerializeField] GameObject cardPrefab;
        [SerializeField] List<Card> myCards;
        [SerializeField] Transform cardSpawnPoint;

        List<Word> wordBuffer;

        public Word PopWord()
        {
            if (wordBuffer.Count == 0)
                SetupWordBuffer();

            Word word = wordBuffer[0];
            wordBuffer.RemoveAt(0);
            return word;
        }

        void SetupWordBuffer()
        {
            wordBuffer = new List<Word>();
            for (int i = 0; i < wordSO.words.Length; i++)
            {
                Word word = wordSO.words[i];
                for (int j = 0;j < word.percent;j++)
                    wordBuffer.Add(word);
            }

            for (int i = 0; i < wordBuffer.Count; i++)
            {
                int rand = Random.Range(i, wordBuffer.Count);
                Word temp = wordBuffer[i];
                wordBuffer[i] = wordBuffer[rand];
                wordBuffer[rand] = temp;
            }
        }

        void Start()
        {
            SetupWordBuffer();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                AddCard();
        }

        void AddCard()
        {
            var cardObject = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);
            var card = cardObject.GetComponent<Card>();
            card.Setup(PopWord());
            myCards.Add(card);

            SetOriginOrder();
            CardAlignment();
        }

        void SetOriginOrder()
        {
            int count = myCards.Count;
            for (int i = 0;i < count;i++)
            {
                var targetCard = myCards[i];
                targetCard?.GetComponent<Order>().SetOriginOrder(i);
            }
        }

        void CardAlignment()
        {
            var targetCards = myCards;

            for (int i = 0;i < targetCards.Count;i++) 
            {
                var targetCard = targetCards[i];

                targetCard.originPRS = new PRS(Vector3.zero, Util.QI, new Vector3(1.896733f, 2.910432f, 1));
                targetCard.MoveTransform(targetCard.originPRS,true,0.7f);
            }
        }

    }
}
