using System;
using System.Collections.Generic;
using System.Linq;

namespace cowsay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var strContent = "";
            AnimalMode animalMode = AnimalMode.Regular;
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-b":
                        animalMode = AnimalMode.Borg;
                        break;
                    case "-d":
                        animalMode = AnimalMode.Dead;
                        break;
                    case "-g":
                        animalMode = AnimalMode.Greedy;
                        break;
                    case "-p":
                        animalMode = AnimalMode.Paranoid;
                        break;
                    case "-s":
                        animalMode = AnimalMode.Stoned;
                        break;
                    case "-t":
                        animalMode = AnimalMode.Tired;
                        break;
                    case "-w":
                        animalMode = AnimalMode.Wired;
                        break;
                    case "-y":
                        animalMode = AnimalMode.Youthful;
                        break;

                    case "-n":
                    case "-W":
                    case "-e":
                    case "-T":
                    case "-f":
                    case "-l":
                        throw new NotImplementedException();

                    default:
                        strContent += $"{arg} ";
                        break;
                }
            }
            var animalRenderer = new AnimalRenderer(strContent.Trim(), new RenderOptions
            {
                AnimalMode = animalMode
            });
			animalRenderer.Render();
			foreach(var line in animalRenderer.Builder)
			{
				Console.WriteLine(line);
			}
        }
    }

    public enum AnimalMode
    {
        Regular,
        Borg,
        Dead,
        Greedy,
        Paranoid,
        Stoned,
        Tired,
        Wired,
        Youthful
    }

    public class RenderOptions
    {
        public bool DisableWordWrap { get; set; } = false;

        public uint SpeechBalloonWidth { get; set; } = 40;

        public AnimalMode AnimalMode { get; set; } = AnimalMode.Regular;
    }

    public class AnimalRenderer
    {
        private RenderOptions _renderOptions { get; set; }

        public string SpeechContent { get; private set; }

        public IList<string> Builder { get; private set; }

        public AnimalRenderer(string speechContent, RenderOptions renderOptions)
        {
            _renderOptions = renderOptions;
            SpeechContent = speechContent;
			Builder = new List<string>();
        }

        public string Render()
        {
            DrawSpeechBubble();
			DrawCow();
			
            return null;
        }

        private void DrawSpeechBubble()
        {
            var lineLength = _renderOptions.SpeechBalloonWidth - 4;
            var output = SpeechContent.SplitInParts((int)lineLength).ToArray();
            var lines = output.Length;
			var wrapperLineLength = (lines == 1 ? output.First().Length : (int)_renderOptions.SpeechBalloonWidth - 4) + 2;
			
            Builder.Add($" {'_'.RepeatChar(wrapperLineLength)}");
            if (lines == 1)
            {
                Builder.Add($"< {output.First()} >");
            }
            else
            {
                for (var i = 0; i < lines; i++)
                {
                    char lineStartChar = '|';
                    char lineEndChar = '|';

                    if (i == 0)
                    {
                        lineStartChar = '/';
                        lineEndChar = '\\';
                    }
                    else if (i == lines - 1)
                    {
                        lineStartChar = '\\';
                        lineEndChar = '/';
                    }

					var neededPadding = (int) _renderOptions.SpeechBalloonWidth - 4 - output[i].Length;
                    Builder.Add($"{lineStartChar} {output[i]}{' '.RepeatChar(neededPadding)} {lineEndChar}");
                }
            }
			
            Builder.Add($" {'-'.RepeatChar(wrapperLineLength)}");
        }
		
		private void DrawCow()
		{
			var startingLinePadding = Builder.First().Length / 4;
			
			var eyeChar = 'o';
			var tongueChar = ' ';
			
			switch(_renderOptions.AnimalMode)
			{
				case AnimalMode.Borg:
					eyeChar = '=';
					break;
					
				case AnimalMode.Dead:
					eyeChar = 'x';
					tongueChar = 'U';
					break;
					
				case AnimalMode.Greedy:
					eyeChar = '$';
					break;
					
				case AnimalMode.Paranoid:
					eyeChar = '@';
					break;
					
				case AnimalMode.Stoned:
					eyeChar = '*';
					tongueChar = 'U';
					break;
					
				case AnimalMode.Tired:
					eyeChar = '-';
					break;
					
				case AnimalMode.Wired:
					eyeChar = 'O';
					break;
					
				case AnimalMode.Youthful:
					eyeChar = '.';
					break;
					
			}
			
			Builder.Add($"{' '.RepeatChar(startingLinePadding)}\\   ^__^");
			Builder.Add($"{' '.RepeatChar(startingLinePadding)} \\  ({eyeChar.RepeatChar(2)})\\_______");
			Builder.Add($"{' '.RepeatChar(startingLinePadding)}    (__)\\       )\\/\\");
			Builder.Add($"{' '.RepeatChar(startingLinePadding)}     {tongueChar.RepeatChar(1)}  ||----w |");
			Builder.Add($"{' '.RepeatChar(startingLinePadding)}        ||     ||");
		}
    }

    public static class Extensions
    {
        public static IEnumerable<String> SplitInParts(this String s, int partLength)
        {
            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static string RepeatChar(this char @char, int count)
        {
            var charArray = new char[count];
            for (var i = 0; i < count; i++)
                charArray[i] = @char;

            return new string(charArray);
        }
    }
}
