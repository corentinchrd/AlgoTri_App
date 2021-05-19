/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la classe des positions
 Date : 19.05.2021
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public class Position
    {
        private List<int> _position;
        public List<int> position { get => _position; set => _position = value; }
        public Position(List<int> p)
        {
            position = p;
        }

    }
}
