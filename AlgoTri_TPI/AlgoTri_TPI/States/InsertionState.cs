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
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        private List<RectangleValue> _rectangles;
        private Tri.Insertiontri insertionTri;
        private AfficherInsertion afficherInsertion;
        private List<Position> _allPosition;
        public List<EtapeImage> EtapeList;
        public int etape;
        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }
        public List<RectangleValue> Rectangles { get => _rectangles; set => _rectangles = value; }
        public List<int> tableauPosition;
        Texture2D buttonTexture;
        int speed = 0;
        public InsertionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            EtapeList = new List<EtapeImage>();
            insertionTri = new Tri.Insertiontri();
            insertionTri.Random();
            insertionTri.Sort();
            AllPosition = new List<Position>();
            AllPosition = insertionTri._lp;
            tableauPosition = new List<int>();
            etape = 1;
            for (int i = 0; i < 20; i++)
            {
                tableauPosition.Add(152 + i * 45);
            }
            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, AllPosition, this);
            _components = new List<Component>();
            Rectangles = new List<RectangleValue>();

            Controls.Button Vitesse = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Vitesse",
            };

            Vitesse.Click += VitesseButton_Click;
            _components.Add(Vitesse);

            Controls.Button etapeSuivante = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 650),
                Text = "Etape suivante",
            };

            etapeSuivante.Click += EtapeSuivant_Click;

            _components.Add(etapeSuivante);
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
            afficherRectangle();
        }

        private void VitesseButton_Click(object sender, EventArgs e)
        {
            Controls.Button PasAPas = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Pas a Pas",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(PasAPas);

            Controls.Button TresLent = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Tres lent",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(TresLent);

            Controls.Button Lent = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Lent",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(Lent);

            Controls.Button Normal = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Normal",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(Normal);
            Controls.Button Rapide = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Rapide",
            };

            PasAPas.Click += PasAPasButton_Click;
            _components.Add(Rapide);

        }

        private void PasAPasButton_Click(object sender, EventArgs e)
        {
            Controls.Button b = sender as Controls.Button;

            switch (b.Text)
            {
                case "Pas a pas":
                    speed = 0;
                    RemoveAllButton();
                    break;
                case "Tres lent":
                    speed = 1;
                    RemoveAllButton();
                    break;
                case "Lent":
                    speed = 2;
                    RemoveAllButton();
                    break;
                case "Normal":
                    speed = 3;
                    RemoveAllButton();
                    break;
                case "Rapide":
                    speed = 4;
                    RemoveAllButton();
                    break;
            }
        }
        public void RemoveAllButton() {
            foreach (Controls.Button item in _components)
            {
                if (item.Text == "Pas a pas" || item.Text == "Tres lent" || item.Text == "Lent" || item.Text == "Normal" || item.Text == "Rapide") {
                    _components.Remove(item);
                }
            }
            
        }
        private void EtapeSuivant_Click(object sender, EventArgs e)
        {

            if (etape == 2)
            {

                if (afficherInsertion.currentState != 21)
                {
                    EtapeList[etape].opacity = EtapeList[etape].opacity / 2;
                    EtapeList[etape - 1].opacity = EtapeList[etape - 1].opacity * 2;
                    Rectangles = afficherInsertion.AfficherNextPosAndState();
                    etape--;
                    afficherInsertion.currentState++;
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

        }

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
            spriteBatch.DrawString(buttonFont, "0", new Vector2(215, 750), Color.Red);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //destroy object when needed
        }

        public override void Update(GameTime gameTime)
        {


            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }
        public void afficherRectangle()
        {
            Rectangles = afficherInsertion.afficherList();
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Add(rectangle);
            }
        }
    }
}
