/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la vue du Tri par séléction
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoTri_TPI.Affichage;

namespace AlgoTri_TPI.States
{
    public class SelectionState : State
    {
        #region Champ
        private List<Component> _components;
        private Texture2D _rectangleSprite;
        private SpriteFont _buttonFont;
        private List<RectangleValue> _rectangles;
        private Tri.SelectionTri _selectionTri;
        private AfficherSelection _afficherSelection;
        private List<Position> _allPosition; 
        private Texture2D _buttonTexture;
        private int _speed = 0;
        private int _old = 0;
        #endregion
        #region Propriete
        public List<EtapeImage> EtapeList;
        public int etape = 1;
        public int compteur = 0;
        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }
        public List<RectangleValue> Rectangles { get => _rectangles; set => _rectangles = value; }
        public List<int> tableauPosition;
        #endregion
        
        public SelectionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _buttonTexture = _content.Load<Texture2D>("Controls/Button");
            _rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            _buttonFont = _content.Load<SpriteFont>("Fonts/File");
            EtapeList = new List<EtapeImage>();
            _selectionTri = new Tri.SelectionTri();
            AllPosition = new List<Position>();
            _selectionTri.Random();
            _selectionTri.Sort();
            AllPosition = _selectionTri._lp;
            tableauPosition = new List<int>();
            etape = 1;
            // ajout des positions fixe du tableau 
            for (int i = 0; i < 20; i++)
            {
                tableauPosition.Add(152 + i * 45);
            }

            _afficherSelection = new AfficherSelection(_rectangleSprite, _buttonFont, AllPosition, this);
            _components = new List<Component>();
            Rectangles = new List<RectangleValue>();
            afficherRectangle();

            #region Button
            Controls.Button etapeSuivante = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(1100, 750),
                Text = "Etape suivante",
            };
            Controls.Button PasAPas = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(200, 100),
                Text = "Pas a Pas",
            };

            PasAPas.Click += Speed_Click;
            _components.Add(PasAPas);

            Controls.Button TresLent = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(400, 100),
                Text = "Tres lent",
            };

            TresLent.Click += Speed_Click;
            _components.Add(TresLent);

            Controls.Button Lent = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(600, 100),
                Text = "Lent",
            };

            Lent.Click += Speed_Click;
            _components.Add(Lent);

            Controls.Button Normal = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(800, 100),
                Text = "Normal",
            };

            Normal.Click += Speed_Click;
            _components.Add(Normal);
            Controls.Button Rapide = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(1000, 100),
                Text = "Rapide",
            };

            Rapide.Click += Speed_Click;
            _components.Add(Rapide);

            Controls.Button Random = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(500, 750),
                Text = "Random",
            };

            Random.Click += Random_Click;
            _components.Add(Random);

            Controls.Button BestCase = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(700, 750),
                Text = "Meilleur cas",
            };

            BestCase.Click += BestCase_Click;
            _components.Add(BestCase);

            Controls.Button WorstCase = new Controls.Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(900, 750),
                Text = "Pire cas",
            };

            WorstCase.Click += WorstCase_Click;
            _components.Add(WorstCase);
            etapeSuivante.Click += EtapeSuivant_Click;

            _components.Add(etapeSuivante);

            #endregion

            #region Etape
            EtapeImage etapeImage1 = new EtapeImage(content.Load<Texture2D>("Sprites/Selection/tile000"), new Vector2(200, 430), 0.5f * 2);
            EtapeImage etapeImage2 = new EtapeImage(content.Load<Texture2D>("Sprites/Selection/tile001"), new Vector2(200, 450), 0.5f);
            EtapeImage etapeImage3 = new EtapeImage(content.Load<Texture2D>("Sprites/Selection/tile002"), new Vector2(200, 470), 0.5f);
            EtapeImage etapeImage4 = new EtapeImage(content.Load<Texture2D>("Sprites/Selection/tile003"), new Vector2(200, 490), 0.5f);
            EtapeImage etapeImage5 = new EtapeImage(content.Load<Texture2D>("Sprites/Selection/tile004"), new Vector2(200, 510), 0.5f);

            EtapeList.Add(etapeImage1);
            EtapeList.Add(etapeImage2);
            EtapeList.Add(etapeImage3);
            EtapeList.Add(etapeImage4);
            EtapeList.Add(etapeImage5);

            _components.Add(etapeImage1);
            _components.Add(etapeImage2);
            _components.Add(etapeImage3);
            _components.Add(etapeImage4);
            _components.Add(etapeImage5);
            #endregion
        }
        /// <summary>
        /// Permet de donner le pire des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorstCase_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            _selectionTri = new Tri.SelectionTri();
            _selectionTri.WorstCase();
            _selectionTri.Sort();
            AllPosition = _selectionTri._lp;
            etape = 1;
            _afficherSelection = new AfficherSelection(_rectangleSprite, _buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// Permet de donner le meilleurs des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BestCase_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            _selectionTri = new Tri.SelectionTri();
            _selectionTri.BestCase();
            _selectionTri.Sort();
            AllPosition = _selectionTri._lp;
            etape = 1;
            _afficherSelection = new AfficherSelection(_rectangleSprite, _buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// permet de donner des valeurs aléatoire a la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Random_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            _selectionTri = new Tri.SelectionTri();
            _selectionTri.Random();
            _selectionTri.Sort();
            AllPosition = _selectionTri._lp;
            etape = 1;
            _afficherSelection = new AfficherSelection(_rectangleSprite, _buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// Fonction permetant la vitesse d'exécution du tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speed_Click(object sender, EventArgs e)
        {
            Controls.Button b = sender as Controls.Button;

            switch (b.Text)
            {
                case "Pas a Pas":
                    _speed = 0;
                    break;
                case "Tres lent":
                    _speed = 1;
                    break;
                case "Lent":
                    _speed = 2;
                    break;
                case "Normal":
                    _speed = 3;
                    break;
                case "Rapide":
                    _speed = 4;
                    break;
            }
        }
        /// <summary>
        /// permet d'afficher l'étape en cours dans la liste des étapes et de faire bouger les rectangles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtapeSuivant_Click(object sender, EventArgs e)
        {
            if (_afficherSelection.currentState != _allPosition.Count)
            {
                switch (etape)
                {
                    case 0:
                        EtapeList[_old].opacity /= 2;
                        EtapeList[etape].opacity *= 2;
                        _old = 0;
                        etape++;
                        break;
                    case 1:
                        EtapeList[_old].opacity /= 2;
                        EtapeList[etape].opacity *= 2;
                        Rectangles = _afficherSelection.AfficherNextPosAndState();
                        etape++;
                        _old = 1;
                        break;
                    case 2:
                        EtapeList[_old].opacity /= 2;
                        EtapeList[etape].opacity *= 2;
                        Rectangles = _afficherSelection.AfficherNextPosAndState();
                        _old = 2;
                        etape++;
                        break;
                    case 3:
                        EtapeList[_old].opacity /= 2;
                        EtapeList[etape].opacity *= 2;
                        Rectangles = _afficherSelection.AfficherNextPosAndState();
                        _afficherSelection.currentState++;
                        _old = 3;
                        etape = 1;
                        break;
                }
            }
        }
        /// <summary>
        /// Fontion appelée aprs l'update pour dessiner les composants
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
            {
                if (component is RectangleValue)
                {
                    RectangleValue tmp = component as RectangleValue;
                    spriteBatch.Draw(tmp.Texture,
                        new Rectangle((int)tmp.Position.X, (int)tmp.Position.Y - (tmp.HEIGHT * tmp.Value - tmp.HEIGHT), tmp.width, tmp.HEIGHT * tmp.Value),
                        new Rectangle(0, 0, 1, 1), tmp.Color);
                    tmp.Draw(gameTime, spriteBatch);
                }
                else
                {
                    component.Draw(gameTime, spriteBatch);
                }
            }
            spriteBatch.DrawString(_buttonFont, "Nombre d'iteration(s) :", new Vector2(15, 750), Color.Black);
            spriteBatch.DrawString(_buttonFont, compteur.ToString(), new Vector2(215, 750), Color.Red);
            spriteBatch.End();
        }
        /// <summary>
        /// Fonction appelée apres l'update pour suprimer des éléments
        /// </summary>
        /// <param name="gameTime"></param>
        public override void PostUpdate(GameTime gameTime)
        {

        }
        /// <summary>
        /// fonctin appelée le plus souvant possible
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            switch (_speed)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            foreach (Component component in _components.ToArray())
            {
                component.Update(gameTime);
            }
        }
        /// <summary>
        /// Permet d'afficher tous les rectangles
        /// </summary>
        public void afficherRectangle()
        {
            if (Rectangles.Count != 0)
            {
                foreach (RectangleValue rectangle in Rectangles)
                {
                    _components.Remove(rectangle);
                }
            }            
            Rectangles = _afficherSelection.afficherList();
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Add(rectangle);
            }
        }
    }
}
