using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Contra
{
    public class DragonBoss : SingletonBehaviour<DragonBoss>
    {
        public GameObject walls;
        public GameObject bossUI;
        public List<GameObject> lives;

        public GameObject bulletWingLeft;
        public GameObject bulletWingRight;
        public GameObject rockWingLeft;
        public GameObject rockWingRight;
        public GameObject centerNormal;
        public GameObject centerHoming;

        public Animator dragonAnimator;

        public bool coreAvailable = false;

        private int life = 3;

        public void Setup()
        {
            walls.SetActive(true);
            bossUI.SetActive(true);
        }

        public void Finish()
        {
            walls.SetActive(false);
            bossUI.SetActive(false);
            CameraTracker.Instance.TrackPlayer();
        }

        public void DamageWing0()
        {
            bulletWingLeft.SetActive(false);

            if (!bulletWingLeft.activeSelf && !bulletWingRight.activeSelf)
            {
                coreAvailable = true;
                rockWingLeft.SetActive(true);
                rockWingRight.SetActive(true);
            }
        }

        public void DamageWing1()
        {
            bulletWingRight.SetActive(false);

            if (!bulletWingLeft.activeSelf && !bulletWingRight.activeSelf)
            {
                coreAvailable = true;
                rockWingLeft.SetActive(true);
                rockWingRight.SetActive(true);
            }
        }



        public void DamageBoss()
        {
            if (life == 3)
            {
                centerNormal.SetActive(true);
            }
            else if (life == 2)
            {
                centerHoming.SetActive(true);
            }
            else if (life == 1)
            {
                Finish();
                return;
            }

            life--;
        }
    }
}
