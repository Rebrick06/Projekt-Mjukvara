using System.Data.SQLite;

namespace KattApp
{
    public partial class App : Application
    {
        public static DataBase _db = new DataBase();
        public App()
        {
            InitializeComponent();
        }

        public class DataBase
        {
            private string _dataBasePath;
            SQLiteConnection _connection;
            SQLiteCommand _command;

            private void Open()
            {
                if (_connection != null)
                {
                    _connection.Open();
                }
            }

            private void Close()
            {
                if (_connection != null)
                {
                    _connection.Close();
                }
            }

            public DataBase()
            {
                _dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "MyCats.db");
                _connection = new SQLiteConnection(_dataBasePath);
                _command = new SQLiteCommand("SELECT SQLITE_VERSION();", _connection);

                /*    if (!File.Exists(_dataBasePath)) // Om filen inte redan finns, skapar "MyCats.db", kanske inte behövs
                    {
                        SQLiteConnection.CreateFile(_dataBasePath);
                    }*/
                TryCreateTable();
            }

            public void TryCreateTable() // OM TABELLEN INTE FINNS, SKapar den
            {
                Open();
                //BILDER??
                string cmdString = @"
                CREATE TABLE IF NOT EXISTS Cats (
Id INTEGER PRIMARY KEY AUTOINCREMENT, 
Name TEXT,
Race TEXT,
Birthday TEXT,
Food_type TEXT,
Food_amount INTEGER,
Weight REAL,
Comment TEXT
)";
                _command.CommandText = cmdString;
                _command.ExecuteNonQuery();
                Close();
            }

            public bool AddCat(Cat cat)
            {
                try
                {
                    Open();
                    _command.CommandText = "INSERT INTO Cats (Name, Race, Birthday, Food_type, Food_amount, Weight, Comment) VALUES (@name, @race, @bday, @food_type, @food_amount, @weight, @comment);";

                    SQLiteParameter nameParam = new SQLiteParameter("@name", System.Data.DbType.String);
                    SQLiteParameter raceParam = new SQLiteParameter("@race", System.Data.DbType.String);
                    SQLiteParameter bdayParam = new SQLiteParameter("@bday", System.Data.DbType.String);
                    SQLiteParameter food_typeParam = new SQLiteParameter("@food_type", System.Data.DbType.String);
                    SQLiteParameter food_amountParam = new SQLiteParameter("@food_amount", System.Data.DbType.Int32);
                    SQLiteParameter weightParam = new SQLiteParameter("@weight", System.Data.DbType.Double);
                    SQLiteParameter commentParam = new SQLiteParameter("@comment", System.Data.DbType.String);

                    nameParam.Value = cat._name;
                    raceParam.Value = cat._race;
                    bdayParam.Value = cat._bday;
                    food_typeParam.Value = cat._food_type;
                    food_amountParam.Value = cat._food_amount;
                    weightParam.Value = cat._weight;

                    commentParam.Value = cat._comment;

                    _command.Parameters.Add(nameParam);
                    _command.Parameters.Add(raceParam);
                    _command.Parameters.Add(bdayParam);
                    _command.Parameters.Add(food_typeParam);
                    _command.Parameters.Add(food_amountParam);
                    _command.Parameters.Add(weightParam);
                    _command.Parameters.Add(commentParam);

                    _command.Prepare();
                    _command.ExecuteNonQuery();
                    Close();

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public List<Cat> getData()
            {
                List<Cat> cats = new List<Cat> ();
                List<string> names = new List<string>();
                List<string> races = new List<string>();
                List<string> bdays = new List<string>();
                List<string> food_types = new List<string>();
                List<int> food_amounts = new List<int>();
                List<double> weights = new List<double>();
                List<string> comments = new List<string>();
                Open();
                _command.CommandText = "SELECT * FROM Cats;";

                using SQLiteDataReader rdr = _command.ExecuteReader();
                while(rdr.Read())
                {
                    names.Add(rdr.GetString(1));
                    races.Add(rdr.GetString(2));
                    bdays.Add(rdr.GetString(3));
                    food_types.Add(rdr.GetString(4));
                    food_amounts.Add(rdr.GetInt32(5));
                    weights.Add(rdr.GetDouble(6));
                    comments.Add(rdr.GetString(7));
                }
                Close();
                for(int i=0; i<names.Count; i++)
                {
                    cats.Add(new Cat(names[i], races[i], bdays[i], food_types[i], food_amounts[i], weights[i], comments[i]));
                }
                return cats;
            }
        }

        public class Cat
        {
            public string _name { get; set; }
            public string _race { get; set; }
            public string _bday { get; set; }
            public string _food_type { get; set; }
            public int _food_amount { get; set; }
            public double _weight { get; set; }
            public string _comment { get; set; }
            public Cat(string name, string race, string bDay, string food_type, int food_amount, double weight, string comment)
            {
        _name = name;
        _race = race;
        _bday = bDay;
        _food_type = food_type;
        _food_amount = food_amount;
        _weight = weight;
        _comment = comment;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}