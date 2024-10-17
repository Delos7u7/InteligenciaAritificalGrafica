using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Game.Player
{
    public class Actor
    {
        public Bitmap texture = null;
        public int X = 0;
        public int Y = 0;
        private List<Bitmap> textureList = new List<Bitmap>();
        private int count = 0;
        public Actor(string path) 
        {
            Bitmap t = new Bitmap(path);
            t.MakeTransparent(Color.Transparent);
            textureList.Add(t);
            texture = t;

        }

        public void AddTexture(string path)
        {
            Bitmap t = new Bitmap(path);
            t.MakeTransparent (Color.Transparent);
            textureList.Add(t);
            //texture = textureList.ElementAt(0);
        }

        public void NextTexture()
        {
            count++;
            if (count > textureList.Count-1)
            {
                count = 0;
            }
            texture = textureList.ElementAt(count);
        }
    }
}
