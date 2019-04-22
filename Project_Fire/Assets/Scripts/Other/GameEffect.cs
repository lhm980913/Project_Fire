using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class GameEffect : UnityEngine.MonoBehaviour
    {
        ParticleSystem ps;
        float playTime;

        [HideInInspector]
        public GameObject parent;

        public void FInit()
        {
            ps = transform.GetComponent<ParticleSystem>();
            gameObject.SetActive(false);
        }

        public void FPlay(float scale)
        {
            playTime = 0;
            gameObject.SetActive(true);
            ps.Play();
            FSetScale(transform, scale);
        }

        public void FSetScale(Transform t,float scale)
        {
            for(int i = 0; i < t.childCount; i++)
            {
                FSetScale(t.GetChild(i), scale);
            }
            t.localScale = new Vector3(scale, scale, scale);
        }

        public void FSetParent(GameObject obj)
        {
            parent = obj;
        }

        private void FDie()
        {
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            playTime += Time.deltaTime;
            if(parent != null)
            {
                transform.position = parent.transform.position;
            }

            if(playTime >= ps.main.duration)
            {
                FDie();
            }
        }
    }

}
