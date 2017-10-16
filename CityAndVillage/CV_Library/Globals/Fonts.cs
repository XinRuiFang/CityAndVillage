using CV_Library.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Globals
{
    public class Fonts
    {
        static Point Unit = new Point(14, 25);
        static Point TimeUnit = new Point(6, 8);
        static Point DateUnit = new Point(13, 8);
        static Point DepositUnit = new Point(7, 16);

        public static void DrawString(string _string, Vector2 position, SpriteBatch b, Color color, float ld, float scale, int charArow)
        {
            char[] charArr = _string.ToCharArray();
            int index = 0;
            int lines = charArr.Length / charArow;
            int rows = charArr.Length % charArow;


            for (int j = 0; j < lines; j++)
            {
                for (int i = 0; i < charArow; i++)
                {
                    b.Draw(ResourceController.Font_small, new Vector2(position.X + i * Unit.X * scale, position.Y + j * Unit.Y * scale), GetFontRect(charArr[index]), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
                    index++;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                b.Draw(ResourceController.Font_small, new Vector2(position.X + i * Unit.X * scale, position.Y + lines * Unit.Y * scale), GetFontRect(charArr[index]), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
                index++;
            }
        }
        static Rectangle GetFontRect(char c)
        {
            
            switch (c)
            {
                case 'A':
                    return new Rectangle(0 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'B':
                    return new Rectangle(1 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'C':
                    return new Rectangle(2 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'D':
                    return new Rectangle(3 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'E':
                    return new Rectangle(4 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'F':
                    return new Rectangle(5 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'G':
                    return new Rectangle(6 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'H':
                    return new Rectangle(7 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'I':
                    return new Rectangle(8 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'J':
                    return new Rectangle(9 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'K':
                    return new Rectangle(10 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'L':
                    return new Rectangle(11 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'M':
                    return new Rectangle(12 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'N':
                    return new Rectangle(13 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'O':
                    return new Rectangle(14 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'P':
                    return new Rectangle(15 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'Q':
                    return new Rectangle(16 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'R':
                    return new Rectangle(17 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'S':
                    return new Rectangle(18 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'T':
                    return new Rectangle(19 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'U':
                    return new Rectangle(20 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'V':
                    return new Rectangle(21 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'W':
                    return new Rectangle(22 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'X':
                    return new Rectangle(23 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'Y':
                    return new Rectangle(24 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);
                case 'Z':
                    return new Rectangle(25 * Unit.X, 0 * Unit.Y, Unit.X, Unit.Y);

                case 'a':
                    return new Rectangle(0 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'b':
                    return new Rectangle(1 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'c':
                    return new Rectangle(2 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'd':
                    return new Rectangle(3 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'e':
                    return new Rectangle(4 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'f':
                    return new Rectangle(5 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'g':
                    return new Rectangle(6 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'h':
                    return new Rectangle(7 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'i':
                    return new Rectangle(8 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'j':
                    return new Rectangle(9 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'k':
                    return new Rectangle(10 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'l':
                    return new Rectangle(11 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'm':
                    return new Rectangle(12 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'n':
                    return new Rectangle(13 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'o':
                    return new Rectangle(14 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'p':
                    return new Rectangle(15 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'q':
                    return new Rectangle(16 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'r':
                    return new Rectangle(17 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 's':
                    return new Rectangle(18 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 't':
                    return new Rectangle(19 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'u':
                    return new Rectangle(20 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'v':
                    return new Rectangle(21 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'w':
                    return new Rectangle(22 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'x':
                    return new Rectangle(23 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'y':
                    return new Rectangle(24 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                case 'z':
                    return new Rectangle(25 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
                
                case '1':
                    return new Rectangle(0 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '2':
                    return new Rectangle(1 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '3':
                    return new Rectangle(2 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '4':
                    return new Rectangle(3 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '5':
                    return new Rectangle(4 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '6':
                    return new Rectangle(5 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '7':
                    return new Rectangle(6 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '8':
                    return new Rectangle(7 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '9':
                    return new Rectangle(8 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '0':
                    return new Rectangle(9 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '.':
                    return new Rectangle(10 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case ',':
                    return new Rectangle(11 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '~':
                    return new Rectangle(12 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '!':
                    return new Rectangle(13 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '@':
                    return new Rectangle(14 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '#':
                    return new Rectangle(15 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case ' ':
                    return new Rectangle(16 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '%':
                    return new Rectangle(17 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '^':
                    return new Rectangle(18 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '&':
                    return new Rectangle(19 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '(':
                    return new Rectangle(20 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case ')':
                    return new Rectangle(21 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '_':
                    return new Rectangle(22 * Unit.X, 2 * Unit.Y, Unit.X, Unit.Y);
                case '-':
                    return new Rectangle(19 * Unit.X, 3 * Unit.Y, Unit.X, Unit.Y);
                case '?':
                    return new Rectangle(20 * Unit.X, 3 * Unit.Y, Unit.X, Unit.Y);
                case ':':
                    return new Rectangle(25 * Unit.X, 3 * Unit.Y, Unit.X, Unit.Y);
                default:
                    return new Rectangle(1 * Unit.X, 1 * Unit.Y, Unit.X, Unit.Y);
            }
        }

        public static void DrawTime(Vector2 position,SpriteBatch b,Color color,float ld,float scale)
        {
            string time = (((int)GlobalController.Time / 60).ToString().Length == 1 ? "0" + ((int)GlobalController.Time / 60).ToString() : ((int)GlobalController.Time / 60).ToString()) + ((int)GlobalController.Time % 2 == 0 ? ":" : " ") + (((int)GlobalController.Time % 60).ToString().Length == 1 ? "0" + ((int)GlobalController.Time % 60).ToString() : ((int)GlobalController.Time % 60).ToString());
            char[] charArr = time.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                b.Draw(ResourceController.Font_time, new Vector2(position.X + i * TimeUnit.X * scale, position.Y), GetFontTimeRect(charArr[i]), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
            }

        }

        public static void DrawDate(Vector2 position, SpriteBatch b, Color color, float ld, float scale)
        {
            string date = "";
            /*
            switch (GlobalController.Season)
            {
                case 1:
                    date += "Spring ";
                    break;
                case 2:
                    date += "Summer ";
                    break;
                case 3:
                    date += "Autumn ";
                    break;
                case 4:
                    date += "Winter ";
                    break;
                default:
                    break;
            }
             * */
            date += GlobalController.Date;
            switch (int.Parse(GlobalController.Date.ToString().Substring(GlobalController.Date.ToString().Length - 1, 1)))
            {
                case 1:
                    date += "st ";
                    break;
                case 2:
                    date += "nd ";
                    break;
                case 3:
                    date += "rd ";
                    break;
                default:
                    date += "th ";
                    break;
            }
            switch (GlobalController.WeekDay)
            {
                case 1: date += "Mon."; break;
                case 2: date += "Tue."; break;
                case 3: date += "Wed."; break;
                case 4: date += "Thu."; break;
                case 5: date += "Fri."; break;
                case 6: date += "Sat."; break;
                case 7: date += "Sun."; break;
                default:
                    break;
            }

            DrawString(date, position, b, color, ld, scale, 30);
        }

        public static void DrawDeposit(Vector2 position, SpriteBatch b, Color color, float ld, float scale)
        {
            char[] charArr = GlobalController.Player.Gold.ToString().ToCharArray();
            int length = charArr.Length - 1;
            for (int i = 0; i < charArr.Length; i++)
            {
                b.Draw(ResourceController.Font_deposit, new Vector2(position.X + i * DepositUnit.X * scale - length * DepositUnit.X * 2, position.Y), GetFontDepositRect(charArr[i]), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
            }
        }

        public static void DrawSysFont(string _string, Vector2 position, SpriteBatch b, Color color, float ld, float scale, int charArow)
        {
            int count = _string.Length;
            int rows = count / charArow;
            int rest = count % charArow;
            for (int i = 0; i < rows; i++)
            {
                b.DrawString(ResourceController.Fonts_UI, _string.Substring(i * charArow, charArow), new Vector2(position.X,position.Y + 15 * i), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
            }
            b.DrawString(ResourceController.Fonts_UI, _string.Substring(rows * charArow, rest), new Vector2(position.X, position.Y + 15 * rows), color, 0, Vector2.Zero, scale, SpriteEffects.None, ld);
        }

        static Rectangle GetFontTimeRect(char c)
        {
            switch (c)
            {
                case '1':
                    return new Rectangle(0 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '2':
                    return new Rectangle(1 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '3':
                    return new Rectangle(2 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '4':
                    return new Rectangle(3 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '5':
                    return new Rectangle(4 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '6':
                    return new Rectangle(5 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '7':
                    return new Rectangle(6 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '8':
                    return new Rectangle(7 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '9':
                    return new Rectangle(8 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case '0':
                    return new Rectangle(9 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case ':':
                    return new Rectangle(10 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                case ' ':
                    return new Rectangle(11 * TimeUnit.X, 0 * TimeUnit.Y, TimeUnit.X, TimeUnit.Y);
                default:
                    return new Rectangle();
            }     
            
        }
        static Rectangle GetFontDateRect(char c)
        {
            switch (c)
            {
                case '1':
                    return new Rectangle(0 * DateUnit.X, 0 * DateUnit.Y, DateUnit.X, DateUnit.Y);
                case '2':
                    return new Rectangle(1 * DateUnit.X, 0 * DateUnit.Y, DateUnit.X, DateUnit.Y);
                case '3':
                    return new Rectangle(2 * DateUnit.X, 0 * DateUnit.Y, DateUnit.X, DateUnit.Y);
                default:
                    return new Rectangle(3 * DateUnit.X, 0 * DateUnit.Y, DateUnit.X, DateUnit.Y);
            }
            
        }

        static Rectangle GetFontDepositRect(char c)
        {
            switch (c)
            {
                case '1':
                    return new Rectangle(0 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '2':
                    return new Rectangle(1 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '3':
                    return new Rectangle(2 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '4':
                    return new Rectangle(3 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '5':
                    return new Rectangle(4 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '6':
                    return new Rectangle(5 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '7':
                    return new Rectangle(6 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '8':
                    return new Rectangle(7 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '9':
                    return new Rectangle(8 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                case '0':
                    return new Rectangle(9 * DepositUnit.X, 0 * DepositUnit.Y, DepositUnit.X, DepositUnit.Y);
                default:
                    return new Rectangle();
            }     
        }
    }
}
