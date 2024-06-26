using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Map_scene
{
    public class MapMove : MonoBehaviour
    {
        [SerializeField] GameObject character;
        [SerializeField] GameObject village;
        [SerializeField] GameObject battle1;
        [SerializeField] GameObject battle2;
        [SerializeField] GameObject battle3;
        [SerializeField] GameObject boss;
        int position = 0;

        void Update()
        {
            CharacterMove();
        }

        void CharacterMove()
        {
            if (position == 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    character.transform.DOMove(battle1.transform.position,1);
                    position++;
                }
            }

            else if(position == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    character.transform.DOMove(battle2.transform.position,1);
                    position++;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    character.transform.DOMove(village.transform.position,1);
                    position--;
                }
            }

            else if(position == 2)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    character.transform.DOMove(battle3.transform.position,1);
                    position++;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    character.transform.DOMove(battle1.transform.position,1);
                    position--;
                }
            }

            else if(position == 3)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    character.transform.DOMove(boss.transform.position,1);
                    position++;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    character.transform.DOMove(battle2.transform.position,1);
                    position--;
                }
            }

            else if(position == 4)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    character.transform.DOMove(battle3.transform.position,1);
                    position--;
                }
            }
        }

    }
}

