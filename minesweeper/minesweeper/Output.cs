using System.IO;
using System.Text;

namespace minesweeper
{
    public class Output
    {
        private readonly TextWriter _textWriter;

        public Output(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void WriteFieldNumber(int fieldNumber)
        {
            _textWriter.WriteLine($"Field #{fieldNumber}: ");
        }

        public void WriteField(Field field)
        {
            _textWriter.WriteLine(FieldToString(field));
        }

        public string FieldToString(Field field)
        {
            var stringBuilder = new StringBuilder();
            for (var y = 0; y < field.Rows; y++)
            {
                for (var x = 0; x < field.Cols; x++)
                {
                    var cell = field.GetCell(new Location(x, y));
                    stringBuilder.Append(cell.IsMine ? "*" : field.CountNeighbouringMines(new Location(x, y)).ToString());
                }
                if (y < field.Rows-1) stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
    
}