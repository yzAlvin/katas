using System.Collections.Generic;
using System.Linq;

namespace minesweeper
{
    public class Game
    {
        private readonly Input _consoleReader;
        private readonly Output _consoleWriter;
        private readonly List<Field> _fields;

        public Game(Input consoleReader, Output consoleWriter)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _fields = new List<Field>();
        }
        
        public void Play()
        {
            GetFields();
            WriteFields();
        }

        private void GetFields()
        {
            var size = _consoleReader.ReadLine().ToString();
            while (!EndOfInput(size))
            {
                if (!ValidFieldSize(size)) return;

                var successfulField = TryGetField(size, out var field);
                if (!successfulField) return;
                _fields.Add(field);
                
                size = (string) _consoleReader.ReadLine();
            }
        }

        private bool EndOfInput(string input)
        {
            const string endOfInputCode = "00";
            return input == endOfInputCode;
        }

        private bool ValidFieldSize(string input)
        {
            return input.Length == 2 &&
                IsValidInt(input[0]) && IsValidInt(input[1]);
                
        }

        private bool IsValidInt(char size) => int.TryParse(size.ToString(), out var dimension)  && dimension > 0;

        private bool TryGetField(string size, out Field field)
        {
            var rows = GetRows(size);
            var cols = GetCols(size);
            field = new Field(rows, cols);

            for (var y = 0; y < rows; y++)
            {
                var row = _consoleReader.ReadLine().ToString();
                if (!ValidRow(row, cols)) return false;
                for (var x = 0; x < cols; x++)
                {
                    if (row[x] == '*') field.SetMine(new Location(x, y));
                }
            }

            return true;
        }
        
        private int GetRows(string input) => int.Parse(input[0].ToString());
        
        private int GetCols(string input) => int.Parse(input[1].ToString());

        private bool ValidRow(string row, int width)
        {
            const char mine = '*';
            const char safe = '.';
            return row.Length == width && row.All(c => c == mine || c == safe);
        }

        private void WriteFields()
        {
            for (var i = 0; i < _fields.Count; i++)
            {
                _consoleWriter.WriteFieldNumber(i+1);
                _consoleWriter.WriteField(_fields[i]);
            }
        }
    }
}