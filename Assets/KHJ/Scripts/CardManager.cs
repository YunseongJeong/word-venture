using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;
using Quaternion = UnityEngine.Quaternion;
using System;
using Unity.VisualScripting;

namespace Deck_Manage {
    public class CardManager : MonoBehaviour
    {
        public static CardManager Inst {get; private set;}
        void Awake() => Inst = this;

        [SerializeField] WordSO wordSO;
        [SerializeField] GameObject cardPrefab;
        [SerializeField] List<Card> myCards;
        [SerializeField] Transform cardSpawnPoint;
        [SerializeField] Transform CardLeft;
        [SerializeField] Transform CardRight;
        [SerializeField] GameObject PushArea;

        List<Word> wordBuffer;
        public Card selectCard;
        bool isMyCardDrag;
        bool onCardArea;
        bool onPushArea;

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
            if (Input.GetKeyDown(KeyCode.Space) && !isMyCardDrag)
                AddCard();

            DetectCardArea();
            if (isMyCardDrag)
            {
                // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // mousePosition = new Vector3(mousePosition.x, mousePosition.y, selectCard.transform.position.z);
                // selectCard.transform.position = mousePosition;
                DragCard();
            }
            
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
            List<PRS> originCardPRSs = new List<PRS>();
            originCardPRSs = RoundAlignment(CardLeft, CardRight, myCards.Count, 0.5f, new Vector3(1.896733f, 2.1f, 1) * 0.4f);

            var targetCards = myCards;

            for (int i = 0;i < targetCards.Count;i++) 
            {
                var targetCard = targetCards[i];

                targetCard.originPRS = originCardPRSs[i];
                //targetCard.originPRS = new PRS(Vector3.zero, Util.QI, new Vector3(1.896733f, 2.910432f, 1));
                targetCard.MoveTransform(targetCard.originPRS,true,0.7f);
            }
        }

        List<PRS> RoundAlignment(Transform Left, Transform Right, int objCount, float height, Vector3 scale)
        {
            float[] objLerps = new float[objCount];
            List<PRS> results = new List<PRS>(objCount);

            float interval = 1f / (objCount+1);
            for (int i = 0;i < objCount;i++)
                objLerps[i] = interval * (i+1);
            
            for (int i = 0;i< objCount;i++)
            {
                var targetPos = Vector3.Lerp(Left.position, Right.position, objLerps[i]);
                var targetRot = Quaternion.identity;

                float curve = Mathf.Sqrt(Mathf.Pow(height, 2) - Mathf.Pow(objLerps[i] - 0.5f, 2));
                targetPos.y += curve;
                targetRot = Quaternion.Slerp(Left.rotation, Right.rotation, objLerps[i]);

                results.Add(new PRS(targetPos, targetRot, scale));
            }
            return results;
        }

        #region MyCard

        public void CardMouseOver(Card card)
        {
            if(!onPushArea)
            {
                EnlargeCard(true, card);
            }
        }

        public void CardMouseExit(Card card)
        {
            if(!onPushArea)
            {
                EnlargeCard(false, card);
            }   
        }

        public void CardMouseDown()
        {
            isMyCardDrag = true;
        }

        public void CardMouseUp()
        {
            isMyCardDrag = false;
            if(onPushArea)
            {
                selectCard.MoveTransform(new PRS(PushArea.transform.position, Util.QI, selectCard.originPRS.scale), false);
            }
        }

        void DragCard()
        {
            if (!onCardArea && !onPushArea)
            {
                selectCard.MoveTransform(new PRS(Util.MousePos, Util.QI, selectCard.originPRS.scale), false);
            }
            
            else if (onPushArea)
            {
                selectCard.MoveTransform(new PRS(PushArea.transform.position, Util.QI, selectCard.originPRS.scale), false);
            }
        }

        void DetectCardArea()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Util.MousePos, Vector3.forward);
            int Cardlayer = LayerMask.NameToLayer("CardArea");
            int Pushlayer = LayerMask.NameToLayer("PushArea");
            onCardArea = Array.Exists(hits, x => x.collider.gameObject.layer == Cardlayer);
            onPushArea = Array.Exists(hits, x => x.collider.gameObject.layer == Pushlayer);
        }

        void EnlargeCard(bool isEnlarge, Card card)
        {
            if (isEnlarge)
            {
                Vector3 enlargePos = new Vector3(card.originPRS.pos.x, -3f, -10f);
                card.MoveTransform(new PRS(enlargePos, Util.QI, new Vector3(1.896733f, 2.1f, 1) * 0.6f), false);
            }
            else
                card.MoveTransform(card.originPRS, false);

            card.GetComponent<Order>().SetMostFrontOrder(isEnlarge);
        }

        #endregion
    }
}
