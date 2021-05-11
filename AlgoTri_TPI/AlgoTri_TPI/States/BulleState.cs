using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoTri_TPI.Affichage;
using AlgoTri_TPI.Tri;

namespace AlgoTri_TPI.States
{
    public class BulleState : State
    {
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        private List<RectangleValue> _rectangles;
        private Tri.BulleTri bulleTri;
        private AfficherBulle afficherBulle;
        private List<Position> _allPosition;
        List<EtapeImage> EtapeList;
        int etape;
        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }
        public List<RectangleValue> Rectangles { get => _rectangles; set => _rectangles = value; }
        public List<int> tableauPosition;
        public BulleState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            EtapeList = new List<EtapeImage>();
            bulleTri = new Tri.BulleTri();
            bulleTri.Random();
            bulleTri.Sort();
            AllPosition = new List<Position>();
            AllPosition = bulleTri.Lp;

            tableauPosition = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                tableauPosition.Add(152 + i * 45);
            }
            afficherBulle = new AfficherBulle(rectangleSprite, buttonFont, AllPosition, this);
            _components = new List<Component>();
            Rectangles = new List<RectangleValue>();

            Controls.Button etapeSuivant = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 650),
                Text = "Etape precedente",
            };

            etapeSuivant.Click += SelectionButton_Click;
            _components.Add(etapeSuivant);

            Controls.Button etapeSuivante = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 650),
                Text = "Etape suivante",
            };

            etapeSuivante.Click += EtapeSuivant_Click;

            _components.Add(etapeSuivante);
            EtapeImage etapeImage1 = new EtapeImage(content.Load<Texture2D>("Sprites/1"), new Vector2(200, 450), 0.5f * 2);
            EtapeImage etapeImage2 = new EtapeImage(content.Load<Texture2D>("Sprites/2"), new Vector2(200, 470), 0.5f);
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

        private void SelectionButton_Click(object sender, EventArgs e)
        {
            if (etape > 0)
            {
                etape--;
                EtapeList[etape + 1].opacity = EtapeList[etape + 1].opacity / 2;

                EtapeList[etape].opacity = EtapeList[etape].opacity * 2;
            }
            Rectangles = afficherBulle.AfficherPrevPos();

        }
        private void EtapeSuivant_Click(object sender, EventArgs e)
        {
            if (etape + 1 <= EtapeList.Count - 1)
            {
                etape++;
                EtapeList[etape - 1].opacity = EtapeList[etape - 1].opacity / 2;
                EtapeList[etape].opacity = EtapeList[etape].opacity * 2;

            }
            Rectangles = afficherBulle.AfficherNextPos();
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
            Rectangles = afficherBulle.afficherList();
            foreach (RectangleValue rectangle in Rectangles)
            {
                _components.Add(rectangle);
            }
        }
    }
}
