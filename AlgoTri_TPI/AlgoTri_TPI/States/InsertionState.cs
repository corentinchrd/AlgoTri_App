/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la vue du Tri a shell
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
    public class InsertionState : State
    {
        #region Champ
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        private List<RectangleValue> _rectangles;
        private Tri.Insertiontri insertionTri;
        private AfficherInsertion afficherInsertion;
        private List<Position> _allPosition;
        Texture2D buttonTexture;
        int speed = 0;
        #endregion
        #region Propriete
        public List<EtapeImage> EtapeList;
        public int etape;
        public int compteur = 0;
        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }
        public List<RectangleValue> Rectangles { get => _rectangles; set => _rectangles = value; }
        public List<int> tableauPosition;
        #endregion
        public InsertionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            EtapeList = new List<EtapeImage>();
            insertionTri = new Tri.Insertiontri();
            AllPosition = new List<Position>();
            AllPosition = insertionTri._lp;
            tableauPosition = new List<int>();
            etape = 1;
            // coordonée polaire a l'emplacement dans le tableau
            for (int i = 0; i < 20; i++)
            {
                tableauPosition.Add(152 + i * 45);
            }

            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, AllPosition, this);
            _components = new List<Component>();
            Rectangles = new List<RectangleValue>();

            #region Button
            Controls.Button etapeSuivante = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1100, 750),
                Text = "Etape suivante",
            };
            Controls.Button PasAPas = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 100),
                Text = "Pas a Pas",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(PasAPas);

            Controls.Button TresLent = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(400, 100),
                Text = "Tres lent",
            };

            TresLent.Click += PasAPasButton_Click;
            _components.Add(TresLent);

            Controls.Button Lent = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(600, 100),
                Text = "Lent",
            };

            Lent.Click += PasAPasButton_Click;
            _components.Add(Lent);

            Controls.Button Normal = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(800, 100),
                Text = "Normal",
            };

            Normal.Click += PasAPasButton_Click;
            _components.Add(Normal);
            Controls.Button Rapide = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1000, 100),
                Text = "Rapide",
            };

            Rapide.Click += PasAPasButton_Click;
            _components.Add(Rapide);

            Controls.Button Random = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(700, 600),
                Text = "Random",
            };

            Random.Click += Random_Click;
            _components.Add(Random);

            Controls.Button BestCase = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(900, 600),
                Text = "Meilleur cas",
            };

            BestCase.Click += BestCase_Click;
            _components.Add(BestCase);

            Controls.Button WorstCase = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1100, 600),
                Text = "Pire cas",
            };

            WorstCase.Click += WorstCase_Click;
            _components.Add(WorstCase);
            etapeSuivante.Click += EtapeSuivant_Click;

            _components.Add(etapeSuivante);

            #endregion

            #region Etape
            EtapeImage etapeImage1 = new EtapeImage(content.Load<Texture2D>("Sprites/1"), new Vector2(200, 450), 0.5f);
            EtapeImage etapeImage2 = new EtapeImage(content.Load<Texture2D>("Sprites/2"), new Vector2(200, 470), 0.5f * 2);
            EtapeImage etapeImage3 = new EtapeImage(content.Load<Texture2D>("Sprites/3"), new Vector2(200, 490), 0.5f);
            EtapeImage etapeImage4 = new EtapeImage(content.Load<Texture2D>("Sprites/4"), new Vector2(200, 510), 0.5f);

            EtapeList.Add(etapeImage1);
            EtapeList.Add(etapeImage2);
            EtapeList.Add(etapeImage3);
            EtapeList.Add(etapeImage4);
            _components.Add(etapeImage1);
            _components.Add(etapeImage2);
            _components.Add(etapeImage3);
            _components.Add(etapeImage4);
            #endregion
        }
        /// <summary>
        /// Permet de donner le pire des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorstCase_Click(object sender, EventArgs e)
        {
            insertionTri = new Tri.Insertiontri();
            insertionTri.WorstCase();
            insertionTri.Sort();
            AllPosition = insertionTri._lp;
            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// Permet de donner le meilleurs des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BestCase_Click(object sender, EventArgs e)
        {
            insertionTri = new Tri.Insertiontri();
            insertionTri.BestCase();
            insertionTri.Sort();
            AllPosition = insertionTri._lp;
            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// permet de donner des valeurs aléatoire a la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Random_Click(object sender, EventArgs e)
        {
            insertionTri = new Tri.Insertiontri();
            insertionTri.Random();
            insertionTri.Sort();
            AllPosition = insertionTri._lp;
            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// Permet de choisir la vitesse d'éxécution du tri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasAPasButton_Click(object sender, EventArgs e)
        {
            Controls.Button b = sender as Controls.Button;

            switch (b.Text)
            {
                case "Pas a Pas":
                    speed = 0;
                    break;
                case "Tres lent":
                    speed = 1;
                    break;
                case "Lent":
                    speed = 2;
                    break;
                case "Normal":
                    speed = 3;
                    break;
                case "Rapide":
                    speed = 4;
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
            if (etape == 2)
            {

                if (afficherInsertion.currentState != 21)
                {
                    Rectangles = afficherInsertion.AfficherNextPosAndState();
                    etape++;
                }
            }
            else if (etape == 1)
            {
                if (afficherInsertion.currentState != 21)
                {
                    EtapeList[etape].opacity = EtapeList[etape].opacity / 2;
                    EtapeList[etape + 1].opacity = EtapeList[etape + 1].opacity * 2;
                    Rectangles = afficherInsertion.AfficherNextPosAndState();

                    etape++;
                }
            }
            else if (etape == 3)
            {

                if (afficherInsertion.currentState != 21)
                {
                    EtapeList[etape - 1].opacity = EtapeList[etape - 1].opacity / 2;
                    EtapeList[etape - 2].opacity = EtapeList[etape - 2].opacity * 2;
                    Rectangles = afficherInsertion.AfficherNextPosAndState();
                    afficherInsertion.currentState++;
                    etape = 1; compteur++;
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
            spriteBatch.DrawString(buttonFont, "Nombre d'iteration(s) :", new Vector2(15, 750), Color.Black);
            spriteBatch.DrawString(buttonFont, compteur.ToString(), new Vector2(215, 750), Color.Red);
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
            switch (speed)
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
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Remove(rectangle);
            }
            Rectangles = afficherInsertion.afficherList();
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Add(rectangle);
            }
        }
    }
}
