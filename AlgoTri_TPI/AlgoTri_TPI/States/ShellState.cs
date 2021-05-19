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
    public class ShellState : State
    {
        #region Champ
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        private List<RectangleValue> _rectangles;
        private Tri.ShellTri shellTri; // permet de trier
        private AfficherShell afficherShell; // permet d'afficher
        private List<Position> _allPosition; // liste de toutes les positions du tri
        Texture2D buttonTexture;
        int speed = 0;
        int old = 0;
        #endregion

        #region Propriete
        public List<EtapeImage> EtapeList; // Liste des images pour les étapes
        public int etape = 6;
        public int compteur = 0;
        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }
        public List<RectangleValue> Rectangles { get => _rectangles; set => _rectangles = value; }
        public List<int> tableauPosition;
        #endregion
        public ShellState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            EtapeList = new List<EtapeImage>();
            shellTri = new Tri.ShellTri();
            AllPosition = new List<Position>();
            AllPosition = shellTri._lp;
            tableauPosition = new List<int>();
            //ajoute les coordonées polaire pour les rectangles dans une liste
            for (int i = 0; i < 20; i++)
            {
                tableauPosition.Add(152 + i * 45);
            }

            afficherShell = new AfficherShell(rectangleSprite, buttonFont, AllPosition, this);
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
                Position = new Vector2(500, 750),
                Text = "Random",
            };

            Random.Click += Random_Click;
            _components.Add(Random);

            Controls.Button BestCase = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(700, 750),
                Text = "Meilleur cas",
            };

            BestCase.Click += BestCase_Click;
            _components.Add(BestCase);

            Controls.Button WorstCase = new Controls.Button(buttonTexture, buttonFont)
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
            EtapeImage etapeImage1 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile000"), new Vector2(200, 430), 0.5f * 2);
            EtapeImage etapeImage2 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile001"), new Vector2(200, 450), 0.5f);
            EtapeImage etapeImage3 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile002"), new Vector2(200, 470), 0.5f);
            EtapeImage etapeImage4 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile003"), new Vector2(200, 490), 0.5f);
            EtapeImage etapeImage5 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile004"), new Vector2(200, 510), 0.5f);
            EtapeImage etapeImage6 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile005"), new Vector2(200, 530), 0.5f);
            EtapeImage etapeImage7 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile006"), new Vector2(200, 550), 0.5f);
            EtapeImage etapeImage8 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile007"), new Vector2(200, 570), 0.5f);
            EtapeImage etapeImage9 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile008"), new Vector2(200, 590), 0.5f);
            EtapeImage etapeImage10 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile009"), new Vector2(200, 610), 0.5f);
            EtapeImage etapeImage11 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile010"), new Vector2(200, 630), 0.5f);
            EtapeImage etapeImage12 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile011"), new Vector2(200, 650), 0.5f);
            EtapeImage etapeImage13 = new EtapeImage(content.Load<Texture2D>("Sprites/Shell/PseudoCode/tile012"), new Vector2(200, 670), 0.5f);

            EtapeList.Add(etapeImage1);
            EtapeList.Add(etapeImage2);
            EtapeList.Add(etapeImage3);
            EtapeList.Add(etapeImage4);
            EtapeList.Add(etapeImage5);
            EtapeList.Add(etapeImage6);
            EtapeList.Add(etapeImage7);
            EtapeList.Add(etapeImage8);
            EtapeList.Add(etapeImage9);
            EtapeList.Add(etapeImage10);
            EtapeList.Add(etapeImage11);
            EtapeList.Add(etapeImage12);
            EtapeList.Add(etapeImage13);

            _components.Add(etapeImage1);
            _components.Add(etapeImage2);
            _components.Add(etapeImage3);
            _components.Add(etapeImage4);
            _components.Add(etapeImage5);
            _components.Add(etapeImage6);
            _components.Add(etapeImage7);
            _components.Add(etapeImage8);
            _components.Add(etapeImage9);
            _components.Add(etapeImage10);
            _components.Add(etapeImage11);
            _components.Add(etapeImage12);
            _components.Add(etapeImage13);
            #endregion
        }

        #region Click bouton
        /// <summary>
        /// Permet de donner le pire des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorstCase_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            shellTri = new Tri.ShellTri();
            shellTri.WorstCase();
            shellTri.Sort();
            AllPosition = shellTri._lp;
            afficherShell = new AfficherShell(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// Permet de donner le meilleurs des cas aux valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BestCase_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            shellTri = new Tri.ShellTri();
            shellTri.BestCase();
            shellTri.Sort();
            AllPosition = shellTri._lp;
            afficherShell = new AfficherShell(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
        }
        /// <summary>
        /// permet de donner des valeurs aléatoire a la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Random_Click(object sender, EventArgs e)
        {
            EtapeList[etape].opacity /= 2; EtapeList[1].opacity *= 2;
            shellTri = new Tri.ShellTri();
            shellTri.Random();
            shellTri.Sort();
            AllPosition = shellTri._lp;
            afficherShell = new AfficherShell(rectangleSprite, buttonFont, AllPosition, this); afficherRectangle();
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
            switch (etape)
            {
                case 6:
                    EtapeList[old].opacity /= 2;
                    EtapeList[etape].opacity *= 2;
                    old = 6; Rectangles = afficherShell.AfficherNextPosAndState();
                     etape++;
                    break;
                case 7:
                    EtapeList[old].opacity /= 2;
                    EtapeList[etape].opacity *= 2;
                    Rectangles = afficherShell.AfficherNextPosAndState();
                    old = 7;
                    etape++;
                    break;
                case 8:
                    EtapeList[old].opacity /= 2;
                    EtapeList[etape].opacity *= 2;
                    old = 8;
                    etape = 1;
                    break;
                case 1:
                    EtapeList[old].opacity /= 2;
                    EtapeList[etape].opacity *= 2;
                    old = 1;
                    etape++;
                    break;
                case 2:
                    EtapeList[old].opacity /= 2;
                    EtapeList[etape].opacity *= 2;
                    old = 2;
                    etape = 6;
                    break;

            }
        }
        #endregion
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
                        new Rectangle((int)tmp.Position.X, (int)tmp.Position.Y - (tmp.HEIGHT / 2 * tmp.Value - tmp.HEIGHT), tmp.width, tmp.HEIGHT / 2 * tmp.Value),
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
            Rectangles = afficherShell.afficherList();
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Add(rectangle);
            }
        }

        /// <summary>
        /// Changer de place entre le rectangle1 et rectangle2
        /// </summary>
        /// <param name="rt1">rectangle1</param>
        /// <param name="rt2">rectangle2</param>
        public void InvertTwoRect(RectangleValue rt1, RectangleValue rt2)
        {
            rt1.MoveTo(rt2.StartPos);
            rt2.MoveTo(rt1.StartPos);
        }
    }
}
