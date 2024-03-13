using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace a_Fish
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Hook : MonoBehaviour
    {
        #region [Variablies]

        [Header("# Infos")]
        public Transform hookedTranform;
        private bool canMove = true;
        private int length;
        private int streength;
        private int fishCount;

        [Header("# Camera")]
        [SerializeField] private Camera mainCamera;
        private Vector3 startPos;


        // Components
        private Rigidbody2D rb;
        private Collider2D coll;

        #endregion

        #region [Unity methods]

        private void Awake()
        {
            mainCamera = Camera.main;
            coll = GetComponent<Collider2D>();
        }

        private void Start()
        {
            startPos = transform.position;
        }

        private void Update()
        {
            if (canMove && Input.GetMouseButtonDown(0))
            {
                Vector3 vector = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pos = transform.position;

                pos.x = vector.x;
                transform.position = pos;
            }
        }

        #endregion

        #region [Override]

        #endregion

        public void StartFishing()
        {
            length = -50;
            streength = 3;
            fishCount = 0;
            float time = (-length) * .1f;

            coll.enabled = false;
            canMove = true;

            if(Vector3.Distance(startPos, transform.position) <= .3f)
            {
                StopFishing();
            }
        }

        private void StopFishing()
        {
            canMove = false;
            coll.enabled = true;
        }
    }
}