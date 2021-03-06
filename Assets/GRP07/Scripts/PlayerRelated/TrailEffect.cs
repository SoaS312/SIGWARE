﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class TrailEffect : MonoBehaviour
    {

        [Header("===Lines===")]
        public LineRenderer lineGauche;
        public LineRenderer lineDroite;
        public float setGauche = -0.2f;
        public float setDroite = 0.2f;

        [Header("===Positions===")]
        public int positionY;
        public Vector3 initalPositon;

        [Header("===Classification===")]
        public int index;
        public int numlist;

        [Header("===State===")]
        public bool isBouleDeNeige;

        void Start()
        {
            initalPositon = gameObject.transform.position;
            lineGauche = gameObject.transform.GetChild(0).GetComponent<LineRenderer>();
            lineDroite = gameObject.transform.GetChild(1).GetComponent<LineRenderer>();
            index = 1;
            positionY = 1;
            numlist = 0;
        }

        private void FixedUpdate()
        {
            isBouleDeNeige = Move.staticMove.isBouleDeNeige;
            if (!isBouleDeNeige)
            {
                SpawnTrails();
                lineGauche.SetPosition(index, gameObject.transform.position + new Vector3(-0.2f, 0, 0));
                lineDroite.SetPosition(index, gameObject.transform.position + new Vector3(0.2f, 0, 0));
            }
            if (isBouleDeNeige)
            {
                SpawnTrailBoule();
            lineGauche.SetPosition(index, gameObject.transform.position + new Vector3(-0.08f, 0, 0));
            lineDroite.SetPosition(index, gameObject.transform.position + new Vector3(0.08f, 0, 0));
                lineGauche.SetWidth(0.5f, 0.5f);
                lineDroite.SetWidth(0.5f, 0.5f);
            }
        }

        void SpawnTrails()
        {
            if (lineGauche.positionCount < 1000000 && lineDroite.positionCount < 1000000)
            {
                for (int i = 0; i < lineGauche.positionCount; i++)
                {
                    Vector3 basePositionGauche = lineGauche.GetPosition(i);
                    Vector3 basePositionDroite = lineGauche.GetPosition(i);
                    lineGauche.SetPosition(i, basePositionGauche + new Vector3(0, 1, 0));
                    lineDroite.SetPosition(i, basePositionDroite + new Vector3(0.4f, 1, 0));
                }

                lineGauche.positionCount += 1;
                lineDroite.positionCount += 1;
                index += 1;
                numlist += 1;

                lineGauche.SetPosition(numlist - numlist, gameObject.transform.position + new Vector3(-0.2f, index, 0));
                lineDroite.SetPosition(numlist - numlist, gameObject.transform.position + new Vector3(0.2f, index, 0));
            }

        }

        void SpawnTrailBoule()
        {
            if (lineGauche.positionCount < 1000000 && lineDroite.positionCount < 1000000)
            {
                for (int i = 0; i < lineGauche.positionCount; i++)
                {
                    Vector3 basePositionGauche = lineGauche.GetPosition(i);
                    Vector3 basePositionDroite = lineGauche.GetPosition(i);
                    lineGauche.SetPosition(i, basePositionGauche + new Vector3(0, 1, 0));
                    lineDroite.SetPosition(i, basePositionDroite + new Vector3(0.4f, 1, 0));
                }

                lineGauche.positionCount += 1;
                lineDroite.positionCount += 1;
                index += 1;
                numlist += 1;

                lineGauche.SetPosition(numlist - numlist, gameObject.transform.position + new Vector3(-0.08f, index, 0));
                lineDroite.SetPosition(numlist - numlist, gameObject.transform.position + new Vector3(0.08f, index, 0));
            }

        }
    }
}
