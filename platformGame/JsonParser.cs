using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.IO;
using System.Collections.Generic;

namespace platformGame
{
    internal class JsonParser
    {
        static JObject wholeObj;

        public static void GetObjectFromFile (string fileName)
        {
            StreamReader file = File.OpenText(fileName);
            JsonReader reader = new JsonTextReader(file);
            wholeObj = JObject.Load(reader);

        }

        public static Rectangle GetRectangle(JObject obj)
        {
            int x = Convert.ToInt32(obj.GetValue("positionX"));
            int y = Convert.ToInt32(obj.GetValue("positionY"));
            int height = Convert.ToInt32(obj.GetValue("height"));
            int width = Convert.ToInt32(obj.GetValue("width"));

            Rectangle rect = new Rectangle(x, y, width, height);
            return rect; 

        }


        public static Rectangle GetRectangle(string fileName, string propertyName)
        {

            GetObjectFromFile(fileName);

            JObject obj = (JObject)wholeObj.GetValue (propertyName);

            
            return GetRectangle(obj);


        }

        public static List<Rectangle> GetRectangleList(string fileName, string propertyName)
        {

            GetObjectFromFile(fileName);
            List<Rectangle> rectList = new List<Rectangle>();
            JArray arrayObj = (JArray)wholeObj.GetValue (propertyName);

            for (int i = 0; i < arrayObj.Count; i++)
            {
                JObject obj = (JObject)arrayObj[i];
                Rectangle rect = GetRectangle(obj);
                rectList.Add(rect);
            }

            return rectList;

        }


    }
}
